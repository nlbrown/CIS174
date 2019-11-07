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
        private readonly IPersonService _service;
        public Assgn10Controller(IPersonService service)
        {
            _service = service;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonCreateCommandModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var person = _service.Create(model);
            if (person != null) return RedirectToAction("Index", "Home");
            return View();
        }


    }

}