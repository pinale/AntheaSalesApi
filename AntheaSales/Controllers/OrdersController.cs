using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AntheaSales.Models;
using AntheaSales.ViewModels;
using Effort;
using Effort.Provider;

namespace AntheaSales.Controllers
{
    public class OrdersController : ApiController
    {

        // GET: api/Orders
        public IQueryable<OrderViewModel> Get()
        {
            SalesDbContext db = GetFakeDataContext();

            List<OrderViewModel> ovmList = new List<OrderViewModel>();
            foreach (Order _order in db.Orders)
            {
                _order.Calculate();
                OrderViewModel ovm = new OrderViewModel();
                ovm.OrderDescription = _order.OrderDescription;
                ovm.OrderDate = _order.Date;
                ovm.SalesTaxes = _order.SalesTaxes;
                ovm.Total = _order.Total;

                foreach (OrderItem _item in _order.Items)
                {
                    ovm.Items.Add(new OrderItemViewModel()
                    {
                        Description = _item.Product.Description,
                        Quantity = _item.Quantity,
                        Price = _item.TotalAmount
                    }
                    );
                }
                ovmList.Add(ovm);
            }

            return ovmList.AsQueryable();
        }

        // GET: api/Orders/5
        [ResponseType(typeof(OrderViewModel))]
        public IHttpActionResult Get(int id)
        {
            SalesDbContext db = GetFakeDataContext();

            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            order.Calculate();

            OrderViewModel ovm = new OrderViewModel();
            ovm.OrderDescription = order.OrderDescription;
            ovm.OrderDate = order.Date;
            ovm.SalesTaxes = order.SalesTaxes;
            ovm.Total = order.Total;

            foreach (OrderItem _item in order.Items)
            {
                ovm.Items.Add(new OrderItemViewModel() {
                                    Description = _item.Product.Description,
                                    Quantity = _item.Quantity,
                                    Price = _item.TotalAmount }
                );
            }

            return Ok(ovm);
        }


        private SalesDbContext GetFakeDataContext()
        {
            EffortConnection connection = DbConnectionFactory.CreateTransient();
            SalesDbContext context = new SalesDbContext(connection);

            context.OrderItems.RemoveRange(context.OrderItems.ToList());
            context.Orders.RemoveRange(context.Orders.ToList());
            context.Products.RemoveRange(context.Products.ToList());
            context.Categories.RemoveRange(context.Categories.ToList());
            context.SaveChanges();

            var booksCat = new Category() { Description = "Books", SalesTax = 0d };
            var foodCat = new Category() { Description = "Food", SalesTax = 0d };
            var medicalCat = new Category() { Description = "Medical", SalesTax = 0d };
            var musicCat = new Category() { Description = "Music", SalesTax = 10d };
            var cosmeticsCat = new Category() { Description = "Cosmetics", SalesTax = 10d };
            var veichlesCat = new Category() { Description = "Vehicles", SalesTax = 10d };
            var technologyCat = new Category() { Description = "Technology", SalesTax = 10d };

            context.Categories.Add(booksCat);
            context.Categories.Add(foodCat);
            context.Categories.Add( musicCat);
            context.Categories.Add(cosmeticsCat);
            context.Categories.Add(veichlesCat);
            context.Categories.Add(technologyCat);


            var bookProd = new Product() { Description = "book", Price = 12.49, Category = booksCat };
            var musicCdProd = new Product() { Description = "music CD", Price = 14.99, Category = musicCat };
            var chocoloareBarProd = new Product() { Description = "chocolate bar", Price = 0.85, Category = foodCat };
            var boxOfChocolateAProd = new Product() { Description = "box of chocolate A", Price = 10.00, ImportTaxRate = 5, Category = foodCat };
            var boxOfChocolateBProd = new Product() { Description = "box of chocolate B", Price = 11.25, ImportTaxRate = 5, Category = foodCat };
            var bottleOfPerfumeAProd = new Product() { Description = "bottle of perfume A", Price = 47.50, ImportTaxRate = 5, Category = cosmeticsCat };
            var bottleOfPerfumeBProd = new Product() { Description = "bottle of perfume B", Price = 27.99, ImportTaxRate = 5, Category = cosmeticsCat };
            var bottleOfPerfumeCProd = new Product() { Description = "bottle of perfume C", Price = 18.99, Category = cosmeticsCat };
            var headachePillsProd = new Product() { Description = "headache pills (packet)", Price = 9.75, Category = medicalCat };


            context.Products.Add(bookProd);
            context.Products.Add(musicCdProd);
            context.Products.Add(chocoloareBarProd);
            context.Products.Add(boxOfChocolateAProd);
            context.Products.Add(boxOfChocolateBProd);
            context.Products.Add(bottleOfPerfumeAProd);
            context.Products.Add(bottleOfPerfumeBProd);
            context.Products.Add(bottleOfPerfumeCProd);
            context.Products.Add(headachePillsProd);


            var orderItem1_1 = new OrderItem() { Product = bookProd, Quantity = 2 };
            var orderItem2_1 = new OrderItem() { Product = musicCdProd, Quantity = 1 };
            var orderItem3_1 = new OrderItem() { Product = chocoloareBarProd, Quantity = 1 };
            var order1 = new Order() { OrderDescription = "Order 1", Date = new DateTime(2019, 01, 10), Items = new List<OrderItem> { orderItem1_1, orderItem2_1, orderItem3_1 } };

            var orderItem1_2 = new OrderItem() { Product = boxOfChocolateAProd, Quantity = 1 };
            var orderItem2_2 = new OrderItem() { Product = bottleOfPerfumeAProd, Quantity = 1 };
            var order2 = new Order() { OrderDescription = "Order 2", Date = new DateTime(2019, 02, 20), Items = new List<OrderItem> { orderItem1_2, orderItem2_2, } };

            var orderItem1_3 = new OrderItem() { Product = bottleOfPerfumeBProd, Quantity = 1 };
            var orderItem2_3 = new OrderItem() { Product = bottleOfPerfumeCProd, Quantity = 1 };
            var orderItem3_3 = new OrderItem() { Product = headachePillsProd, Quantity = 1 };
            var orderItem4_3 = new OrderItem() { Product = boxOfChocolateBProd, Quantity = 3 };
            var order3 = new Order() { OrderDescription = "Order 3", Date = new DateTime(2019, 03, 5), Items = new List<OrderItem> { orderItem1_3, orderItem2_3, orderItem3_3, orderItem4_3 } };

            context.Orders.Add(order1);
            context.Orders.Add(order2);
            context.Orders.Add(order3);

            context.SaveChanges();

            return context;
        }



        //// PUT: api/Orders/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutOrder(int id, Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != order.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Orders
        //[ResponseType(typeof(Order))]
        //public IHttpActionResult PostOrder(Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Orders.Add(order);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        //}

        //// DELETE: api/Orders/5
        //[ResponseType(typeof(Order))]
        //public IHttpActionResult DeleteOrder(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Orders.Remove(order);
        //    db.SaveChanges();

        //    return Ok(order);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}