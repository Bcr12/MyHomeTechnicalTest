using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeTechnicalTest.BizObjects
{
    public class SearchRequest
    {
        public string BedsString { get; set; }
        public int? Price { get; set; }
        public string County { get; set; }
        public string Town { get; set; }
        public string PropertyType { get; set; }
        public string BerRating { get; set; }
    }
}
