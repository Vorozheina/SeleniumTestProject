using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestAPIWithRestSharpTestProject.Helpers;

namespace RestAPIWithRestSharpTestProject.Base
{
    public static class Data
    {
        private static string[] ProxyDataStrings()
        {
            string proxyFile = Properties.Resources.Proxy;

            return proxyFile.Split('\n');

        }

        public static Proxy GetProxy()
        {
            string[] dataStrings = ProxyDataStrings();
                        
            Random rnd = new Random();
            int i = rnd.Next(1, dataStrings.Length);

            char[] delimiterChars = { ' ', ':', '\t' };
            string[] parsedStrings = dataStrings[i].Split(delimiterChars);
            
            Proxy proxy = new Proxy();
            proxy.Id = Convert.ToInt32(parsedStrings[0]);
            proxy.IP = parsedStrings[1];
            proxy.Port = Convert.ToInt32(parsedStrings[2]);
            proxy.Country = parsedStrings[3];
            proxy.City = parsedStrings[4];

            return proxy;
        }
    }
}
