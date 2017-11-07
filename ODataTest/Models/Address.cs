using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ODataTest.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string StreetSuffix { get; set; }

        public string ZipCode { get; set; }
    }
}