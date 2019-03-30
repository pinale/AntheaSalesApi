using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntheaSales.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Items = new List<OrderItemViewModel>();
        }

        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
        public double SalesTaxes { get; set; }
        public double Total { get; set; }

    }
}