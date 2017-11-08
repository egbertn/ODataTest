using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataTest.Models
{
    /// <summary>
    /// wrapper for OData Multiple EntityType reponse (Instead of PageResult because that has a Bug, it ignores the given count)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ODataResponse<T> where T : class
    {
        
        [JsonProperty("@odata.context")]
        public string context { get; set; }
        public IEnumerable<T> value { get; set; }
        [JsonProperty("@odata.count")]
        public int count { get; set; }
        public string continuation { get; set; }

    }
}