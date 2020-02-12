using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WP_Test.DataProviders;
using WP_Test.Models;

namespace WP_Test_UnitTests.MockDataProviders
{
    public class MockEmptyPeopleDataProvider : IPeopleDataProvider
    {
        public async Task<IEnumerable<Person>> GetPeopleAsync(string query)
        {
            return await Task.Run(() => new List<Person>());
           
        }
    }
}
