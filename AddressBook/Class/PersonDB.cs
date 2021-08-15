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
        /// <summary>
        /// Adds a contact to the database
        /// </summary>
        /// <param name="person">The person to be added</param>
        public static void Add(Person person)
        {
            using (AddressContext context = new AddressContext())
            {
                context.People.Add(person);
                context.AddressBooks.Attach(person.AddressBook);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if the person is already in the database
        /// </summary>
        /// <param name="newPerson">The person the user wants to add</param>
        /// <param name="addressBookID">The id of the address book that the user wants to add to</param>
        public static bool CheckForExistingPerson(Person newPerson, int addressBookID)
        {
            using(AddressContext context = new AddressContext())
            {
                return
                    (from p in context.People
                     where p.FirstName == newPerson.FirstName && p.LastName == newPerson.LastName && 
                     p.AddressBook.AddressBookID == addressBookID
                     select p).Include(a => a.AddressBook).Any();
            }
        }

        /// <summary>
        /// Checks to see if the contact has been changed
        /// </summary>
        /// <param name="person">The contact being changed</param>
        /// <returns></returns>
        public static bool CheckForChanges(Person person)
        {
            using(AddressContext context = new AddressContext())
            {
                return
                    (from p in context.People
                     where p.FirstName == person.FirstName && p.LastName == person.LastName
                     && p.Address == person.Address && p.City == person.City && p.State == person.State
                     && p.ZipCode == person.ZipCode && p.PersonID == person.PersonID
                     && p.AddressBook.AddressBookID == person.AddressBook.AddressBookID
                     && p.PhoneNumber == person.PhoneNumber
                     select p).Any();
            }
        }

        /// <summary>
        /// Saves the changes to a contact to the database
        /// </summary>
        /// <param name="person">The contact being updated</param>
        public static void SaveChanges(Person person)
        {
            using(AddressContext context = new AddressContext())
            {
                context.Entry(person).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets all contacts for the selected address book
        /// </summary>
        /// <param name="id">The id of the address book</param>
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

        /// <summary>
        /// When trying to add someone that already exist in the
        /// database the user will have the option to load the existing
        /// contact
        /// </summary>
        /// <param name="firstName">The first name of the contact</param>
        /// <param name="lastName">The last name of the contact</param>
        /// <param name="id">The id of the address book</param>
        public static Person GetExistingPerson(string firstName, string lastName, int id)
        {
            using(AddressContext context = new AddressContext())
            {
                Person person =
                    (from p in context.People
                     where p.FirstName == firstName && p.LastName == lastName &&
                     p.AddressBook.AddressBookID == id
                     select p).FirstOrDefault();
                return person;
            }
        }

        /// <summary>
        /// Gets a single selected contact from the database
        /// </summary>
        /// <param name="id">The id of the contact</param>
        public static Person GetPerson(int id)
        {
            using(AddressContext context = new AddressContext())
            {
                Person person =
                    (from p in context.People
                     where p.PersonID == id
                     select p).Include(a => a.AddressBook).SingleOrDefault();
                return person;
            }
        }

        /// <summary>
        /// Deletes the selected contact from the database
        /// </summary>
        /// <param name="person">The contact to be deleted</param>
        public static void Delete(Person person)
        {
            using (AddressContext context = new AddressContext())
            {
                context.Entry(person).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
