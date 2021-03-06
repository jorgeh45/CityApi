﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfoAPI.Controllers
{   [Route("api/cities")]
    public class CityController : Controller
    {

        [HttpGet()]
        public JsonResult GetCities() {

            return new JsonResult(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id) {

            var citytoReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);


            if (citytoReturn == null)
            {
                return NotFound();
            }
            else {
                return Ok(citytoReturn);
            }
                
        }


    }
}
