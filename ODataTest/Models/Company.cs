using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ODataTest.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Address> Addresses { get; set; }

    }
}