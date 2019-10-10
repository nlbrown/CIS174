using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult AccessCK(int access)
        {
            return View();
        }
    }
}