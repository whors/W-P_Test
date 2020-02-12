using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WP_Test.DataProviders;
using WP_Test.Models;

namespace WP_Test_UnitTests.MockDataProviders
{
    public class MockPeopleDataProvider : IPeopleDataProvider
    {
        public async Task<IEnumerable<Person>> GetPeopleAsync(string query)
        {
            var result = await Task.Run(() => listOfPeople());

            return result;
        }

        private List<Person> listOfPeople()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person { id = 135, first_name = "Mechelle", last_name = "Boam", email = "mboam3q@thetimes.co.uk", ip_address = "113.71.242.187", latitude = -6.5115909, longitude = 105.652983 });
            people.Add(new Person { id = 396, first_name = "Terry", last_name = "Stowgill", email = "tstowgillaz@webeden.co.uk", ip_address = "143.190.50.240", latitude = -6.7098551, longitude = 111.3479498 });
            people.Add(new Person { id = 107, first_name = "Marty", last_name = "Aldiss", email = "maldiss2y@delicious.com", ip_address = "36.21.197.237", latitude = 51.6553959, longitude = 0.0572553 });

            return people;
        }
    }
}
