using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Class
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        //public List<AddressBook> AddressBooks { get; set; } = new List<AddressBook>();

        public AddressBook AddressBook { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public string PrintMailingLabel()
        {
            return $"{FirstName} {LastName} \n {Address} \n {City} {State} {ZipCode}";
        }
    }
}
