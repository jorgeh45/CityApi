using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Controllers
{
    [Route("api/cities")]
    public class PointOfInterestController : Controller
    {   [HttpGet("{cityid}/pointofinterest")]
        public IActionResult getPointsOfInterest(int cityid) {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityid);

            if (city == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(city.PointsOfInterest);
            }
        }

        [HttpGet("{cityid}/pointofinterest/{id}")]
        public IActionResult getPointOfInterest(int cityid, int id)
        {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityid);

            if (city == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(city.PointsOfInterest.FirstOrDefault(c => c.Id == id));
            }
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            //if (pointOfInterest.Description == pointOfInterest.Name)
            //{
            //    ModelState.AddModelError("Description", "The provided description should be different from the name.");
            //}

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            // demo purposes - to be improved
            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                             c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new
            { cityId = cityId, id = finalPointOfInterest.Id }, finalPointOfInterest);
        }



    }
}