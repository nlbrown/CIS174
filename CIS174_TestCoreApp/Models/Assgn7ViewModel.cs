using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CIS174_TestCoreApp.Models
{
    public class Assgn7ViewModel
    {
        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Range(1,100)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2018", ErrorMessage ="Date is out of range 1/1/1900 & 12/31/2018")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddressAttribute(ErrorMessage = "Not valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Passwd { get; set; }

        [Display(Name = "Confirm Passwor")]
        [Compare("Passwd", ErrorMessage ="The passwords '{1}' and '{0}' do not match")]
        public string ConfirmPasswd { get; set; }

        [Display(Name = "Country")]
        public IEnumerable<string> Country { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
            = new List<SelectListItem>
            { new SelectListItem{Value="", Text="Please Select Country" },
              new SelectListItem{Value="USA", Text="USA" },
              new SelectListItem{Value="Mexico", Text="Mexico" },
              new SelectListItem{Value="Canada",Text="Canada" },
            };
            
    }
}
