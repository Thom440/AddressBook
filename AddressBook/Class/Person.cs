using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Class
{
    /// <summary>
    /// Represents a personal contact
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The id for the contact
        /// </summary>
        [Key]
        public int PersonID { get; set; }

        /// <summary>
        /// The contacts first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// The contacts last name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// The contacts street address
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// The contacts city
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// The contacts state
        /// </summary>
        [Required]
        public string State { get; set; }

        /// <summary>
        /// The contacts zip code
        /// </summary>
        [Required]
        public string ZipCode { get; set; }

        /// <summary>
        /// The contacts phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The address book that the contact belongs to
        /// </summary>
        public AddressBook AddressBook { get; set; }

        /// <summary>
        /// An overridden to string for displaying the contacts name on the form
        /// </summary>
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        /// <summary>
        /// A to string method for printing the mailing label
        /// </summary>
        public string PrintMailingLabel()
        {
            return $"{FirstName} {LastName} \n{Address} \n{City} {State} {ZipCode}";
        }
    }
}
