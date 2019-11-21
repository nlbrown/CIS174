using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Services;

namespace CIS174_TestCoreApp.Filter
{
    public class LogRequestAttruibute : Attribute, IResourceFilter
    {
        private readonly IPersonService _service;
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //update database with currentDate
            _service.LogRequest();

        }


        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("********Using filter After execution");
        }
    }
}
