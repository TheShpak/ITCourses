using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceStationAdministration.Models
{
    public class Name
    {
        [Required]
        [Display(Name = "First name")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public String GetFullName () => FirstName + " " + LastName;
        
    }
    public class Client
    {
        public int ID { get; set; }
        

        public Name Name { get; set; }
        
        public string FullName
        {
            get
            {
                return this.Name.FirstName + " " + this.Name.LastName;
            }
        }
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        public String Address { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public String PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public String Email { get; set; }


        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}