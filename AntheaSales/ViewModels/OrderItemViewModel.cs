using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntheaSales.ViewModels
{
    public class OrderItemViewModel
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}