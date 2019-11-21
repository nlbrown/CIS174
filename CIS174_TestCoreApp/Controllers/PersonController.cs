using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _service;
        public PersonController(IPersonService service)
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
        public IActionResult Index()
        {
            var viewModel = new CreatePersonViewModel
            {
                School = "DMACC"
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(CreatePersonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}