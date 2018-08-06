using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTestProject.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace SeleniumTestProject.Base
{
    public static class Data
    {
        public static Owner GetOwner()
        {
            byte[] jsonBytes = Properties.Resources.Constants;
            string stringJsonConstants = Encoding.UTF8.GetString(jsonBytes);
            Owner owner = JsonConvert.DeserializeObject<Owner>(stringJsonConstants);
            return owner;
        }
    }
}
