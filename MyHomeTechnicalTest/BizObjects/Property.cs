using MyHomeTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeTechnicalTest.BizObjects
{
    public class Property
    {
        public int Id { get; set; }
        public string GroupLogoUrl { get; set; }
        public string BedsString { get; set; }
        public int? Price { get; set; }
        public decimal SizeStringMeters { get; set; }
        public string DisplayAddress { get; set; }
        public string PropertyType { get; set; }
        public string Bath { get; set; }
        public string BerRating { get; set; }

        public virtual ICollection<string> Photos { get; set; }
    }
}
