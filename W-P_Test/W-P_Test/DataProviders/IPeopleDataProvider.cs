using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WP_Test.Models;

namespace WP_Test.DataProviders
{
    public interface IPeopleDataProvider
    {
        Task<IEnumerable<Person>> GetPeople(string query);
    }
}
