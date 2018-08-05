using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GistsFromMyProfileTestProject.Helpers
{
    public class Authentification
    {
        [JsonProperty("Login")]
        public string Login { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

    }
}
