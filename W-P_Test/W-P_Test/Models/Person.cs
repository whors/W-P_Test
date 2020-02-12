using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WP_Test.Models
{
    [Serializable()]
    public class Person : IEquatable<Person>
    {
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public string ip_address { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }


        public bool Equals(Person other)
        {
            if (this.id == other.id && this.first_name == other.first_name 
                && this.last_name == other.last_name && this.email == other.email 
                && this.ip_address == other.ip_address && this.latitude == other.latitude
                && this.longitude == other.longitude)
            {
                return true;
            }
            else return false;
        }
    }
}
