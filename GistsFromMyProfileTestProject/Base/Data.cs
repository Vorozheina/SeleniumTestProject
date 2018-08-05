using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GistsFromMyProfileTestProject.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace GistsFromMyProfileTestProject.Base
{
    public static class Data
    {
        
        public static Authentification GetAuthentification()
        {
            byte[] jsonBytes = Properties.Resources.LoginPassword;
            string jsonString = Encoding.UTF8.GetString(jsonBytes);
            Authentification authentification = JsonConvert.DeserializeObject<Authentification>(jsonString);
            return authentification;
        }

        public static Gist GetRequest(byte[] jsonBytes)
        {
            string jsonString = Encoding.UTF8.GetString(jsonBytes);
            Gist gist = JsonConvert.DeserializeObject<Gist>(jsonString);
            return gist;
        }                    
    }
}
