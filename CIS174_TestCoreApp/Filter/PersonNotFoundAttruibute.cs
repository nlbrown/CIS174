using CIS174_TestCoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using IActionFilter = Microsoft.AspNetCore.Mvc.Filters.IActionFilter;

namespace CIS174_TestCoreApp.Filter
{

    public class PersonNotFoundAttruibute : TypeFilterAttribute
    {
        public PersonNotFoundAttruibute() : base(typeof(PersonNotFoundFilter)) { }

        public class PersonNotFoundFilter : IActionFilter
        {
            private readonly Ch10PeopleService _service;

            public PersonNotFoundFilter(Ch10PeopleService service)
            {
                _service = service;
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                var recipeId = (int)context.ActionArguments["id"];
                if (!_service.DoesPersonExist(recipeId))
                {
                    context.Result = new NotFoundResult();
                }
            }

            public void OnActionExecuted(ActionExecutedContext context) { }
        }
    }
}
