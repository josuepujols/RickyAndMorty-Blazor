using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Response<T> where T : class
    {
        [JsonProperty(PropertyName = "info")]
        public Object Info { get; set; }
        [JsonProperty(PropertyName = "results")]
        public List<T> Results { get; set; }

    }
}
