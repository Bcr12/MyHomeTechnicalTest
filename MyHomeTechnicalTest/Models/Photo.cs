using System;
using System.Collections.Generic;

#nullable disable

namespace MyHomeTechnicalTest.Models
{
    public partial class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
