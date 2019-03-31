using Microsoft.VisualStudio.TestTools.UnitTesting;
using AntheaSales.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntheaSales.ViewModels;
using System.Web.Http;
using System.Web.Http.Results;

namespace AntheaSales.Controllers.Tests
{
    [TestClass()]
    public class OrdersControllerTests
    {
        [TestMethod()]
        public void GetOrder1Test()
        {
            OrdersController controller = new OrdersController();
            var response = (OkNegotiatedContentResult<OrderViewModel>) controller.Get(1);

            //expected output
            Assert.AreEqual(24.98,response.Content.Items[0].Price);
            Assert.AreEqual(16.49, response.Content.Items[1].Price);
            Assert.AreEqual(0.85, response.Content.Items[2].Price);
            Assert.AreEqual(1.50, response.Content.SalesTaxes);
            Assert.AreEqual(42.32, response.Content.Total);
        }

        [TestMethod()]
        public void GetOrder2Test()
        {
            OrdersController controller = new OrdersController();
            var response = (OkNegotiatedContentResult<OrderViewModel>)controller.Get(2);

            //expected output
            Assert.AreEqual(10.50, response.Content.Items[0].Price);
            Assert.AreEqual(54.65, response.Content.Items[1].Price);
            Assert.AreEqual(7.65, response.Content.SalesTaxes);
            Assert.AreEqual(65.15, response.Content.Total);
        }

        [TestMethod()]
        public void GetOrder3Test()
        {
            OrdersController controller = new OrdersController();
            var response = (OkNegotiatedContentResult<OrderViewModel>)controller.Get(3);

            //expected output
            Assert.AreEqual(32.19, response.Content.Items[0].Price);
            Assert.AreEqual(20.89, response.Content.Items[1].Price);
            Assert.AreEqual(9.75, response.Content.Items[2].Price);
            Assert.AreEqual(35.55, response.Content.Items[3].Price);
            Assert.AreEqual(7.90, response.Content.SalesTaxes);
            Assert.AreEqual(98.38, response.Content.Total);
        }
    }
}