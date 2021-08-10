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
        [Key]
        public int AddressBookID { get; set; }

        public List<Person> People { get; set; } = new List<Person>();
    }
}
