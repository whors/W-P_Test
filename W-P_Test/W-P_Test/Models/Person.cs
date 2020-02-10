using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WP_Test.Models
{
    [Serializable()]
    public class Person
    {
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public string ip_address { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }
    }
}
