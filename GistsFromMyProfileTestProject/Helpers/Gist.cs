using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GistsFromMyProfileTestProject.Helpers
{
    public class Gist
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("public", NullValueHandling = NullValueHandling.Ignore)]
        public string Public { get; set; }

        [JsonProperty("files")]
        public Dictionary<string, GistFile> Files { get; set; }

    }

    public class GistFile
    {
        [JsonProperty("content", Required = Required.AllowNull)]
        public string Content { get; set; }

        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }
    }
}
