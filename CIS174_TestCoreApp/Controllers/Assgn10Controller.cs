using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Entity;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class Assgn10Controller : Controller
    {

        public IActionResult Index()
        {
            var viewModel = new Ch10CreatePersonModel
            {

            };

            return View(viewModel);
        }

        public IActionResult GetSummary()
        {
            var viewModel = new Ch10SummaryModel
            {

            };

            return View(viewModel);
        }

    }
}