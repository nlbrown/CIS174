using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Entity
{
    public class Assgn10Accomplishment
    {
        public int id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfAccomplishment { get; set; }
    }
}
