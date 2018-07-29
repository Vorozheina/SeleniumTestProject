using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPITestProject.Helpers
{
    public class Proxy
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public Proxy()
        {
            Id = 0;
            IP = "";
            Port = 0;
            Country = "";
            City = "";
        }
    }
}
