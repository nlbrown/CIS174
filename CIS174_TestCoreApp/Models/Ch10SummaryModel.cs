using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class Ch10SummaryModel
    { 
            public string Summary_Name { get; set; }

            public string Summary_No_Accompliments { get; set; }

            public IEnumerable<Ch10SummaryModel> Summary_List { get; set; }
        
    }
}
