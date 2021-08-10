using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
