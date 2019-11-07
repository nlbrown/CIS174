using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filter
{
    public class ErrorExceptionAttruibute : ExceptionFilterAttribute
    {
        
        public override void OnException(ExceptionContext context)
        {
            
            var error = new
            {
                Success = false,
                Errors = new[] { context.Exception.Message }
            };

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
           
        }
    }
}

