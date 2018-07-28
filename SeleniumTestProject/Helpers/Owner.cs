using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SeleniumTestProject.Helpers
{
    public class Owner
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("Telephone")]
        public string Telephone { get; set; }

        [JsonProperty("pets")]
        public List<Pet> Pets { get; set; }
    }

    public class Pet
    {
        [JsonProperty("PetName")]
        public string PetName { get; set; }

        [JsonProperty("PetBirthDate")]
        public string PetBirthDate { get; set; }

        [JsonProperty("PetType")]
        public string PetType { get; set; }

        [JsonProperty("visits")]
        public List<Visit> Visits { get; set; }
    }

    public class Visit
    {
        [JsonProperty("DescriptionOfVisit")]
        public string DescriptionOfVisit { get; set; }
    }
}
