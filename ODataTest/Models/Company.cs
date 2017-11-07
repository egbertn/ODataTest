using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ODataTest.Models
{
    public class Company
    {
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Company comp)
            {
                return comp.Id == this.Id;
            }
            return false;
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Address> Addresses { get; set; }

    }
}