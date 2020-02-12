using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WP_Test.DataProviders;
using WP_Test.Models;

namespace WP_Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleDataProvider peopleDataProvider;

        public PeopleController(IPeopleDataProvider peopleDataProvider)
        {
            this.peopleDataProvider = peopleDataProvider;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetLondonPeople()
        {
            var listOfPeople =  await this.peopleDataProvider.GetPeopleAsync("city/London/users");
            if (listOfPeople == null || !listOfPeople.Any()){
                return NotFound("No users found or bad request");
            }
            return Ok(listOfPeople);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLondonPeopleWithinFiftyMiles()
        {
            IEnumerable<Person> listOfPeople = await this.peopleDataProvider.GetPeopleAsync("/users");
            if (listOfPeople == null || !listOfPeople.Any())
            {
                return NotFound("No users found or bad request");
            }

            List<Person> people = listOfPeople.ToList();

            double londonLatitudeRef = 51.50853;
            double londonLongitudeRef = -0.12574;
            double distance = Double.MinValue;

            foreach(Person p in people.ToList())
            {
                distance = Helpers.CalculateDistance(londonLatitudeRef, londonLongitudeRef, p.latitude, p.longitude);
                if(distance > 50.0)
                {
                    people.Remove(p);
                }
            }

            return Ok(people);
        }

    }
}
