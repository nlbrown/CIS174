using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class Assgn7Controller : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new Assgn7ViewModel
            {
               
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(Assgn7ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Assgn7");
        }
    }
}