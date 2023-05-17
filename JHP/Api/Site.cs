using System.Text.Json.Serialization;

namespace JHP.Api
{
    public class Site
    {
        [JsonInclude]
        public string Name;
        [JsonInclude]
        public string Url;

        public Site(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }
    }
}
