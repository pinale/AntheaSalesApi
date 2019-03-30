using AntheaSales.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntheaSales.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string OrderDescription { get; set; }
        public virtual List<OrderItem> Items { get; set; }

        public double SalesTaxes { get; set; }
        public double Total { get; set; }

        public void Calculate()
        {
            foreach (OrderItem _item in Items)
            {
                _item.Calculate();
                this.SalesTaxes += _item.TotalSalesTaxAmount + _item.TotalImportTaxAmount;
                this.Total += _item.TotalAmount;
            }
            this.SalesTaxes = this.SalesTaxes.Rnd();
        }

    }
}