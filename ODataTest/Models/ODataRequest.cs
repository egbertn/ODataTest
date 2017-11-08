using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataTest.Models
{
    public class ODataRequest
    {
        [JsonProperty("@odata.id")]
        public Uri id { get; set; }
    }
}