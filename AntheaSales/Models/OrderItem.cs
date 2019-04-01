using AntheaSales.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntheaSales.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public double TotalSalesTaxAmount { get; set; }
        public double TotalImportTaxAmount { get; set; }
        public double TotalAmount { get; set; }

        //public void Calculate()
        //{
        //    double productPrice = this.Product.Price;
        //    double salesTaxRate = this.Product.Category.SalesTax;
        //    double importTaxRate = this.Product.ImportTaxRate ?? 0d;

        //    TotalPrice = productPrice * this.Quantity;
        //    TotalSalesTaxAmount = (((productPrice / 100) * salesTaxRate) * this.Quantity).Rnd();
        //    TotalImportTaxAmount = (((productPrice / 100) * importTaxRate) * this.Quantity).Rnd();

        //    TotalAmount = Math.Round((TotalPrice + TotalSalesTaxAmount + TotalImportTaxAmount),2);
        //}

        public void Calculate()
        {
            double productPrice = this.Product.Price;
            double salesTaxRate = this.Product.Category.SalesTax;
            double importTaxRate = this.Product.ImportTaxRate ?? 0d;

            TotalPrice = productPrice * this.Quantity;
            TotalSalesTaxAmount = ((productPrice / 100) * salesTaxRate).Rnd() * this.Quantity;
            TotalImportTaxAmount = ((productPrice / 100) * importTaxRate).Rnd() * this.Quantity;

            TotalAmount = Math.Round((TotalPrice + TotalSalesTaxAmount + TotalImportTaxAmount), 2);
        }
    }
}