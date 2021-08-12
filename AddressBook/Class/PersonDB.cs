using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Class
{
    public static class PersonDB
    {
        public static void Add(Person person)
        {
            using (AddressContext context = new AddressContext())
            {
                context.People.Add(person);
                context.AddressBooks.Attach(person.AddressBook);
                context.SaveChanges();
            }
        }

        public static bool CheckForExistingPerson(Person newPerson, int addressBookID)
        {
            using(AddressContext context = new AddressContext())
            {
                List<Person> people =
                    (from p in context.People
                     where p.FirstName == newPerson.FirstName && p.LastName == newPerson.LastName
                     select p).Include(a => a.AddressBook).ToList();
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].AddressBook.AddressBookID == addressBookID)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static bool CheckForChanges(Person person)
        {
            using(AddressContext context = new AddressContext())
            {
                Person currentPerson =
                    (from p in context.People
                     where p.FirstName == person.FirstName && p.LastName == person.LastName
                     && p.Address == person.Address && p.City == person.City && p.State == person.State
                     && p.ZipCode == person.ZipCode && p.AddressBook.AddressBookID == person.AddressBook.AddressBookID
                     select p).SingleOrDefault();
                if (currentPerson == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void SaveChanges(Person person)
        {
            using(AddressContext context = new AddressContext())
            {
                context.Entry(person).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static List<Person> GetAllPeople(int id)
        {
            using(AddressContext context = new AddressContext())
            {
                List<Person> people =
                    (from p in context.People
                     where p.AddressBook.AddressBookID == id
                     select p).ToList();
                return people;
            }
        }
    }
}
