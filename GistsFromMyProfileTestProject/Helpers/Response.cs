using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GistsFromMyProfileTestProject.Helpers
{
    public class Response
    {
        [JsonProperty("url")]
        public string Url { get; set;}

        [JsonProperty("forks_url")]
        public string Forks_Url { get; set; }

        [JsonProperty("commits_url")]
        public string Commits_Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("node_id")]
        public string Node_Id { get; set; }

        [JsonProperty("git_pull_url")]
        public string Git_Pull_Url { get; set; }

        [JsonProperty("git_push_url")]
        public string Git_Push_Url { get; set; }

        [JsonProperty("html_url")]
        public string Html_Url { get; set; }

        [JsonProperty("files")]
        public Dictionary<string, ResponseFile> Files { get; set; }

        [JsonProperty("public")]
        public string Public { get; set; }

        [JsonProperty("created_at")]
        public string Created_At { get; set; }

        [JsonProperty("updated_at")]
        public string Updated_At { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("comments_url")]
        public string Comments_Url { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("truncated")]
        public string Truncated { get; set; }

        [JsonProperty("forks")]
        public List<Fork> Forks { get; set; }

        [JsonProperty("history")]
        public List<History> History { get; set; }
        
    }

    public class ResponseFile
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("raw_url")]
        public string Raw_Url { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("truncated")]
        public string Truncated { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }      


    }

    public class Owner
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("node_id")]
        public string Node_Id { get; set; }

        [JsonProperty("avatar_url")]
        public string Avatar_Url { get; set; }

        [JsonProperty("gravatar_id")]
        public string Gravatar_Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("html_url")]
        public string Html_Url { get; set; }

        [JsonProperty("followers_url")]
        public string Followers_Url { get; set; }

        [JsonProperty("following_url")]
        public string Following_Url { get; set; }

        [JsonProperty("gists_url")]
        public string Gists_Url { get; set; }

        [JsonProperty("starred_url")]
        public string Starred_Url { get; set; }

        [JsonProperty("subscriptions_url")]
        public string Subscriptions_Url { get; set; }

        [JsonProperty("organizations_url")]
        public string Organizations_Url { get; set; }

        [JsonProperty("repos_url")]
        public string Repos_Url { get; set; }

        [JsonProperty("events_url")]
        public string Events_Url { get; set; }

        [JsonProperty("received_events_url")]
        public string Received_Events_Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("site_admin")]
        public string Site_Admin { get; set; }
    }

    public class Fork
    {
        [JsonProperty("user")]
        public Owner User { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public string Created_At { get; set; }

        [JsonProperty("updated_at")]
        public string Updated_At { get; set; }

    }

    public class History
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("user")]
        public Owner User { get; set; }

        [JsonProperty("change_status")]
        public Change_Status Change_Status { get; set; }

        [JsonProperty("committed_at")]
        public string Committed_At { get; set; }
    }

    public class Change_Status
    {
        [JsonProperty("deletions")]
        public string Deletions { get; set; }

        [JsonProperty("additions")]
        public string Additions { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }        
    }
}

