using Microsoft.VisualStudio.TestTools.UnitTesting;
using WP_Test.DataProviders;
using WP_Test_UnitTests.MockDataProviders;
using WP_Test.Models;
using WP_Test.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WP_Test_UnitTests
{
    [TestClass]
    public class TestPeopleController
    {

        IPeopleDataProvider _peopleDataProvider;

        [TestMethod]
        public async Task Get_ShouldReturnAllPeopleFromProviderIfResponseOk()
        {
            _peopleDataProvider = new MockPeopleDataProvider();
            var testPeople = GetListOfPeople();
            PeopleController peopleController = new PeopleController(_peopleDataProvider);
            var actionResult = await peopleController.GetLondonPeople() as OkObjectResult;
            var returnList = actionResult.Value as List<Person>;
            
            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult.Value, typeof(IEnumerable<Person>));
            Assert.AreEqual(returnList.Count, testPeople.Count);
            
        }

        [TestMethod]
        public async Task ReturnsNotFound_GivenEmptyResult()
        {
            _peopleDataProvider = new MockEmptyPeopleDataProvider();
            PeopleController peopleController = new PeopleController(_peopleDataProvider);
            var actionResult = await peopleController.GetLondonPeople() as NotFoundObjectResult;

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsTrue(actionResult.StatusCode == 404);
        }

        [TestMethod]
        public async Task Get_ShouldReturnAllPeopleWithin50MilesLondonIfResponseOk()
        {
            _peopleDataProvider = new MockPeopleDataProvider();
            var testPeople = GetListOfPeople();
            PeopleController peopleController = new PeopleController(_peopleDataProvider);
            var actionResult = await peopleController.GetLondonPeopleWithinFiftyMiles() as OkObjectResult;
            var returnList = actionResult.Value as List<Person>;

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult.Value, typeof(IEnumerable<Person>));
            Person p1 = new Person { id = 135, first_name = "Mechelle", last_name = "Boam", email = "mboam3q@thetimes.co.uk", ip_address = "113.71.242.187", latitude = -6.5115909, longitude = 105.652983 };
            Person p2 = new Person { id = 396, first_name = "Terry", last_name = "Stowgill", email = "tstowgillaz@webeden.co.uk", ip_address = "143.190.50.240", latitude = -6.7098551, longitude = 111.3479498 };
            Person p3 = new Person { id = 107, first_name = "Marty", last_name = "Aldiss", email = "maldiss2y@delicious.com", ip_address = "36.21.197.237", latitude = 51.6553959, longitude = 0.0572553 };
            CollectionAssert.DoesNotContain(returnList, p1);
            CollectionAssert.DoesNotContain(returnList, p2);
            Assert.IsTrue(returnList.Contains(p3));

        }


        [TestMethod]
        public async Task FiftyMilesReturnsNotFound_GivenEmptyResult()
        {
            _peopleDataProvider = new MockEmptyPeopleDataProvider();
            PeopleController peopleController = new PeopleController(_peopleDataProvider);
            var actionResult = await peopleController.GetLondonPeopleWithinFiftyMiles() as NotFoundObjectResult;

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsTrue(actionResult.StatusCode == 404);
        }

        private List<Person> GetListOfPeople()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person { id = 135, first_name = "Mechelle", last_name = "Boam", email = "mboam3q@thetimes.co.uk", ip_address = "113.71.242.187", latitude = -6.5115909, longitude = 105.652983 });
            people.Add(new Person { id = 396, first_name = "Terry", last_name = "Stowgill", email = "tstowgillaz@webeden.co.uk", ip_address = "143.190.50.240", latitude = -6.7098551, longitude = 111.3479498 });
            people.Add(new Person { id = 107, first_name = "Marty", last_name = "Aldiss", email = "maldiss2y@delicious.com", ip_address = "36.21.197.237", latitude = 51.6553959, longitude = 0.0572553 });
            return people;
        }

    }
}
