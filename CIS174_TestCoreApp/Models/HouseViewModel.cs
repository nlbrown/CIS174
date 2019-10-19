using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Models
{
    public class HouseViewModel
    {
        public int id { get; set; }

        public  int Bedrooms { get; set; }
   
        public int SquareFeet { get; set; }

        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2018", ErrorMessage = "Date is out of range 1/1/1900 & 12/31/2018")]
        public DateTime DateBuilt { get; set; }

        public string Flooring { get; set; }

    }
}
