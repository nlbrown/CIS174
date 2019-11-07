using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filter
{
    public class LogRequestAttruibute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            DateTime currentDate = DateTime.Now;
            Console.WriteLine("The current date and time of request is  =>"+currentDate);
            // Here is where call would be made to update database with currentDate
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("********Using filter After execution");
        }
    }
}
