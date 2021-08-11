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
    }
}
