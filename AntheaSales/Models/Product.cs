using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntheaSales.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double? ImportTaxRate { get; set; }
        public virtual Category Category { get; set; }
    }
}