using System.Text.Json;
using System.Text.Json.Serialization;

namespace JHP.Api
{
    public  class Config
    {
        public static string Version = "2.2";
        private Config() {
            x = 30;
            y = 30;
            width = 800;
            height = 450;
            opacity = 100;
            sites = new List<Site>();
            topMost = false;
            isHideWindowBorderOnFocusOut = false;
            alarmEnabled = new bool[] { false, false, false, false, false, false, false, false };
            alarmName = "";
            volume = 70;
            tts = false;
            customAlarms = new CustomAlarm[3]
            {
                new CustomAlarm(false, "", 0),
                new CustomAlarm(false, "", 0),
                new CustomAlarm(false, "", 0),
            };
            rate = 0;
            isMaximize = false;
            latestUrl = defaultSite[0].Url;
        }

        [JsonConstructor]
        public Config(int width, int height, int x, int y, int opacity, bool topMost, 
            bool[] alarmEnabled, string alarmName, int volume, bool tts, 
            List<Site> sites, CustomAlarm[] customAlarms, int rate, bool isHideWindowBorderOnFocusOut,
            bool isMaximize, string latestUrl)
        {
            if (customAlarms == null)
            {
                customAlarms = new CustomAlarm[3]
                {
                    new CustomAlarm(false, "", 0),
                    new CustomAlarm(false, "", 0),
                    new CustomAlarm(false, "", 0),
                };
            }
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.opacity = opacity;
            this.sites = sites;
            this.topMost = topMost;
            this.isHideWindowBorderOnFocusOut = isHideWindowBorderOnFocusOut;
            this.alarmEnabled = alarmEnabled;
            this.alarmName = alarmName;
            this.volume = volume;
            this.tts =tts;
            this.customAlarms = customAlarms;
            this.rate = rate;
            this.isMaximize = isMaximize;
            this.latestUrl = latestUrl != null ? latestUrl : defaultSite[0].Url;
        }

        private static readonly Lazy<Config> instance = new Lazy<Config>(() => new Config());

        [JsonIgnore]
        public static Config Instance { get { return instance.Value; } }

        [JsonInclude]
        public int width;
        [JsonInclude]
        public int height;
        [JsonInclude]
        public int x;
        [JsonInclude]
        public int y;
        
        [JsonInclude]
        public int opacity;

        [JsonInclude]
        public int volume;
        [JsonInclude]
        public int rate;
        [JsonInclude]
        public bool isMaximize;

        public List<Site> defaultSite = new List<Site>
        {
            new Site( "넷플릭스", "https://netflix.com" ),
            new Site( "라프텔", "https://laftel.net/" ),
            new Site( "웨이브", "https://www.wavve.com/" ),
            new Site( "티빙", "https://www.tving.com/" ),
            new Site( "쿠팡플레이", "https://coupangplay.com/" ),
            new Site( "디즈니플러스", "https://www.disneyplus.com/" ),
            new Site( "유튜브", "https://youtube.com" ),
            new Site( "트위치", "https://twitch.tv")
        };
        [JsonInclude]
        public List<Site> sites;

        [JsonInclude]
        public bool topMost;

        [JsonInclude] 
        public bool isHideWindowBorderOnFocusOut;

        [JsonInclude]
        public bool[] alarmEnabled;
        [JsonInclude]
        public string alarmName;
        [JsonInclude]
        public bool tts;

        [JsonInclude]
        public CustomAlarm[] customAlarms;

        [JsonInclude]
        public string latestUrl;

        private void Replace(Config c)
        {
            this.width = c.width;
            this.height = c.height;
            this.x = c.x;
            this.y = c.y;
            this.opacity = c.opacity;
            this.topMost= c.topMost;
            this.isHideWindowBorderOnFocusOut = c.isHideWindowBorderOnFocusOut;
            this.alarmEnabled = c.alarmEnabled;
            this.alarmName = c.alarmName;
            this.volume = c.volume;
            this.tts = c.tts;
            this.sites = c.sites;
            this.customAlarms = c.customAlarms;
            this.rate = c.rate;
            this.isMaximize = c.isMaximize;
            this.latestUrl = c.latestUrl;
        }

        public void Save()
        {
            string jsonString = JsonSerializer.Serialize(this);

            File.WriteAllText("config.json", jsonString);
        }

        public void Load()
        {
            if (File.Exists("config.json"))
            {
                string jsonString = File.ReadAllText("config.json");

                this.Replace(JsonSerializer.Deserialize<Config>(jsonString)!);
            }
        }
    }
}
