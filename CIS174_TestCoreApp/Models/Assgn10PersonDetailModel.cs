using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class Assgn10PersonDetailModel
    {
        public int id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
       
        public DateTime BirthDate { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public bool IsDeleted { get; set; }

        public string SetOfAccomplishments { get; set; }
    }
}

