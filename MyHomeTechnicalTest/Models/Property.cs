using System;
using System.Collections.Generic;

#nullable disable

namespace MyHomeTechnicalTest.Models
{
    public partial class Property
    {
        public Property()
        {
        }

        public int Id { get; set; }
        public string GroupLogoUrl { get; set; }
        public string BedsString { get; set; }
        public int? Price { get; set; }
        public decimal SizeStringMeters { get; set; }
        public string DisplayAddress { get; set; }
        public string PropertyType { get; set; }
        public string Bath { get; set; }
        public string BerRating { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
