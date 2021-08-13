using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AddressBook.Class
{
    public static class AddressDB
    {
        /// <summary>
        /// Gets all the address books in the database
        /// </summary>
        public static List<AddressBook> GetAddressBooks()
        {
            using(AddressContext context = new AddressContext())
            {
                List<AddressBook> addressBooks =
                    (from a in context.AddressBooks
                     orderby a.AddressBookName
                     select a).ToList();
                return addressBooks;
            }
        }

        /// <summary>
        /// Adds a new address book to the database
        /// </summary>
        /// <param name="book">The address book to be added</param>
        public static void AddAddressBook(AddressBook book)
        {
            using (AddressContext context = new AddressContext())
            {
                context.AddressBooks.Add(book);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the selected address book
        /// </summary>
        /// <param name="id">The id of the address book</param>
        public static AddressBook GetAddressBook(int id)
        {
            using(AddressContext context = new AddressContext())
            {
                AddressBook addressBook =
                    (from a in context.AddressBooks
                     where a.AddressBookID == id
                     select a).Include(nameof(AddressBook.People)).SingleOrDefault();
                return addressBook;
            }
        }

        /// <summary>
        /// Gets the selected address book from the database
        /// without attaching the contacts to the address book
        /// </summary>
        /// <param name="id">The id of the address book</param>
        public static AddressBook GetCurrentAddressBook(int id)
        {
            using(AddressContext context = new AddressContext())
            {
                AddressBook addressBook =
                    (from a in context.AddressBooks
                     where a.AddressBookID == id
                     select a).SingleOrDefault();
                return addressBook;
            }
        }

        /// <summary>
        /// Deletes the selected address book from the database
        /// </summary>
        /// <param name="addressBook">The address book to be deleted</param>
        public static void Delete(AddressBook addressBook)
        {
            using(AddressContext context = new AddressContext())
            {
                context.Entry(addressBook).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// When trying to create a new address book this will
        /// check to see if that name already exists
        /// </summary>
        /// <param name="name">The name of the potential address book</param>
        public static bool CheckForExistingAddressBook(string name)
        {
            using(AddressContext context = new AddressContext())
            {
                AddressBook addressBook =
                    (from a in context.AddressBooks
                     where a.AddressBookName.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                     select a).SingleOrDefault();
                return addressBook != null;
            }
        }
    }
}
