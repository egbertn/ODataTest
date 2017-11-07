using System;
using System.ComponentModel.DataAnnotations;

namespace ODataTest.Models
{
    public class Address
    {
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Address address)
            {
                return address.Id == this.Id;
            }
            return false;
        }
        [Key]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string StreetSuffix { get; set; }

        public string ZipCode { get; set; }
    }
}