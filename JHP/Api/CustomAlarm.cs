using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JHP.Api
{
    public class CustomAlarm
    {
        [JsonInclude]
        public string Name { get; set; }
        [JsonInclude]
        public long Tick { get; set; }
        [JsonInclude]
        public bool Enabled;

        public CustomAlarm(bool enabled, string name, long tick)
        {
            Enabled = enabled;
            Name = name;
            Tick = tick;
        }
    }
}
