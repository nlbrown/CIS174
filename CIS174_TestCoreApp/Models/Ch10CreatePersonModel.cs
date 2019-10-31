using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class Ch10CreatePersonModel
    {
        
        public int id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2018", ErrorMessage = "Date is out of range 1/1/1900 & 12/31/2018")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        public bool IsDeleted { get; set; }

        [Display(Name = "Set Of Accomplishments")]
        public string SetOfAccomplishments { get; set; }
    }
}
