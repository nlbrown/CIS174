using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace CIS174_TestCoreApp.Controllers
{
    [Route("api/House")]
    public class HousesController : Controller
    {

        HouseViewModel _h1 = new HouseViewModel()
        {

            id = 1,
            Bedrooms = 4,
            SquareFeet = 1854,
            DateBuilt = new DateTime(1973, 05, 28),
            Flooring = "Carpret"
        };

        HouseViewModel _h2 = new HouseViewModel()
        {
            id = 2,
            Bedrooms = 3,
            SquareFeet =  1675,
            DateBuilt = new DateTime(2015, 10, 17),
            Flooring = "Hardwood"
            
        };

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<HouseViewModel> Houses = new List<HouseViewModel>()
            {
                _h1, _h2
            };

            return Ok(Houses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<HouseViewModel> Houses = new List<HouseViewModel>()
            {
                _h1, _h2
            };

            HouseViewModel house = new HouseViewModel();

            foreach (var home in Houses)
            {
                //if (id > 0 && id <= Houses.Count)
                if (id == home.id)
                {
                    return Ok(home);
                }
                
            }
                 return NotFound();
        }

   
      
        // POST api/controller/create
        [HttpPost("create")]
        public IActionResult Create([FromBody] HouseViewModel house)
        {
            return Ok(house);
        }


    }
}