using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntheaSales.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double SalesTax { get; set; }
    }
}