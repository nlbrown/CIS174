using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class Assgn10Controller : Controller
    {
        public Ch10PeopleService _service;
        public Assgn10Controller(Ch10PeopleService service)
        {
            _service = service;
        }

        public IActionResult Ch10SummaryView()
        {
            var models = _service.Ch10SummryView();

            return View(models);
        }


        public IActionResult Create()
        {
            return View("Ch10AddNewPersonView");
        }

        [HttpPost]
        public IActionResult CreatePeople([FromBody]UpdatePeopleCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = _service.Create(command);
                    return RedirectToAction("Ch10AddNewPersonView", new { id = id });
                }
            }
            catch (Exception)
            {
               
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the person "
                    );
            }

            return View(command);
        }


    }

}