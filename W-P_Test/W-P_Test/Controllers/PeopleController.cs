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

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetLondonPeople()
        {
            var listOfPeople =  await this.peopleDataProvider.GetPeople("city/London/users");
            if (listOfPeople == null){
                return NotFound("No users found or bad request");
            }
            return Ok(listOfPeople);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
       
    }
}
