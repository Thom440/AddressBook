﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AddressBook.Class
{
    public static class AddressDB
    {
        public static List<AddressBook> GetAddressBooks()
        {
            using(AddressContext context = new AddressContext())
            {
                List<AddressBook> addressBooks =
                    (from a in context.AddressBooks
                     select a).ToList();

                addressBooks = addressBooks.OrderBy(a => a.AddressBookName).ToList();

                return addressBooks;
            }
        }

        public static void AddAddressBook(AddressBook book)
        {
            using (AddressContext context = new AddressContext())
            {
                context.AddressBooks.Add(book);
                context.SaveChanges();
            }
        }

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

        public static void Delete(AddressBook addressBook)
        {
            using(AddressContext context = new AddressContext())
            {
                context.Entry(addressBook).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

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
