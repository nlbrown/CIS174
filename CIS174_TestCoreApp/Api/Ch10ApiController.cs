using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Filter;
using CIS174_TestCoreApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Api
{
    [Route("api/[controller]")]
    [LogRequestAttruibute]
    [PersonNotFoundAttruibute]
    public class Ch10ApiController : Controller
    {
        public PersonService _service;

        public Ch10ApiController(PersonService service)
        {
            _service = service;
        }

        public IActionResult Ch10SummaryView()
        {
            var models = _service.Ch10SummryView();

            return View(models);
        }
    }
}