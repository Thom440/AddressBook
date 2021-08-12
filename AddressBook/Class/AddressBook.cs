using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Class
{
    public class AddressBook
    {
        /// <summary>
        /// The id for the address book
        /// </summary>
        [Key]
        public int AddressBookID { get; set; }

        /// <summary>
        /// The name of the address book
        /// </summary>
        [Required]
        public string AddressBookName { get; set; }

        /// <summary>
        /// The list of contacts assigned to the address book
        /// </summary>
        public List<Person> People { get; set; } = new List<Person>();

        /// <summary>
        /// An overridden to string method to show the name
        /// of the address book on the form
        /// </summary>
        public override string ToString()
        {
            return AddressBookName;
        }
    }
}
