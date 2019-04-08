using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopTest.Utilities
{
    public class TestData
    {
        private readonly ShopContext _context;
        public TestData(ShopContext context)
        {
            _context = context;
        }
        public async void Initialize()
        {
            // Categories
            List<Category> categoryList = new List<Category>()
            {
                new Category() { Name = "Root"},
                new Category() { Name = "Level 1", ParentCategoryId = 1},
                new Category() { Name = "Level 2", ParentCategoryId = 2},
                new Category() { Name = "Level 2.A", ParentCategoryId = 2},
                new Category() { Name = "Level 3", ParentCategoryId = 3}
            };
            _context.Categories.AddRange(categoryList);
            await _context.SaveChangesAsync();
            // Manufacturers
            List<Manufacturer> manufacturerList = new List<Manufacturer>()
            {
                new Manufacturer() { Name = "M1"},
                new Manufacturer() { Name = "M2"},
                new Manufacturer() { Name = "M3"},
                new Manufacturer() { Name = "M4"}
            };
            _context.Manufacturers.AddRange(manufacturerList);
            await _context.SaveChangesAsync();
            // Products
            List<Product> productList = new List<Product>()
            {
                new Product() {Name = "Test Product 01", CategoryId = 1, UnitPrice = 30M, ManufacturerId = 1},
                new Product() {Name = "Test Product 02", CategoryId = 1, UnitPrice = 30M, ManufacturerId = 1},
                new Product() {Name = "Test Product 03", CategoryId = 2, UnitPrice = 30M, ManufacturerId = 2},
                new Product() {Name = "Test Product 04", CategoryId = 2, UnitPrice = 30M, ManufacturerId = 2},
                new Product() {Name = "Test Product 05", CategoryId = 3, UnitPrice = 30M, ManufacturerId = 2},
                new Product() {Name = "Test Product 06", CategoryId = 3, UnitPrice = 30M, ManufacturerId = 3},
                new Product() {Name = "Test Product 07", CategoryId = 4, UnitPrice = 30M, ManufacturerId = 3},
                new Product() {Name = "Test Product 08", CategoryId = 5, UnitPrice = 30M, ManufacturerId = 4}
            };
            _context.Products.AddRange(productList);
            await _context.SaveChangesAsync();
            // Customers
            List<Customer> customerList = new List<Customer>()
            {
                new Customer() { Name = "Customer 01", ContactInfo = new ContactInfo() {Email = "Test@test.ok", City = "Test City", Street = "Street 01"}},
                new Customer() { Name = "Customer 02", ContactInfo = new ContactInfo() {Email = "Test@test.ok", City = "Test City", Street = "Street 01"}},
                new Customer() { Name = "Customer 03", ContactInfo = new ContactInfo() {Email = "Test@test.ok", City = "Test City", Street = "Street 01"}},
                new Customer() { Name = "Customer 04", ContactInfo = new ContactInfo() {Email = "Test@test.ok", City = "Test City", Street = "Street 01"}},
                new Customer() { Name = "Customer 05", ContactInfo = new ContactInfo() {Email = "Test@test.ok", City = "Test City", Street = "Street 01"}},
                new Customer() { Name = "Customer 06", ContactInfo = new ContactInfo() {Email = "Test@test.ok", City = "Test City", Street = "Street 01"}},
            };
            _context.Customers.AddRange(customerList);
            await _context.SaveChangesAsync();
            // Orders
            List<Order> orderList = new List<Order>()
            {
                new Order() { CustomerId = 1, OrderNote = "Notes regarding this order", OrderLines = new List<OrderLine>()
                    {
                        new OrderLine() { LineQuantity = 3, Product = productList[0]},
                        new OrderLine() { LineQuantity = 4, Product = productList[1]}
                    }
                },
                new Order() { CustomerId = 1, OrderNote = "Notes regarding this order", OrderLines = new List<OrderLine>()
                    {
                        new OrderLine() { LineQuantity = 2, Product = productList[1]},
                        new OrderLine() { LineQuantity = 5, Product = productList[7]},
                        new OrderLine() { LineQuantity = 1, Product = productList[5]}
                    }
                },
                new Order() { CustomerId = 4, OrderNote = "Notes regarding this order", OrderLines = new List<OrderLine>()
                    {
                        new OrderLine() { LineQuantity = 1, Product = productList[2]}
                    }
                },
                new Order() { CustomerId = 5, OrderNote = "Notes regarding this order", OrderLines = new List<OrderLine>()
                    {
                        new OrderLine() { LineQuantity = 7, Product = productList[5]},
                        new OrderLine() { LineQuantity = 5, Product = productList[4]}
                    }
                },
            };
            _context.Orders.AddRange(orderList);
            await _context.SaveChangesAsync();
            //Supplier
            List<Supplier> supplierList = new List<Supplier>()
            {
                new Supplier() { Name = "Supplier 01"},
                new Supplier() { Name = "Supplier 02"},
                new Supplier() { Name = "Supplier 03"}
            };
            _context.Suppliers.AddRange(supplierList);
            await _context.SaveChangesAsync();
            //ProductSupplierPrices
            List<ProductSupplierPrice> productSupplierPriceList = new List<ProductSupplierPrice>()
            {
                new ProductSupplierPrice() { SupplierId = 1, ProductId = 1, Price = 12M},
                new ProductSupplierPrice() { SupplierId = 1, ProductId = 2, Price = 11M},
                new ProductSupplierPrice() { SupplierId = 1, ProductId = 3, Price = 13M},
                new ProductSupplierPrice() { SupplierId = 2, ProductId = 2, Price = 15M},
                new ProductSupplierPrice() { SupplierId = 2, ProductId = 3, Price = 9M},
                new ProductSupplierPrice() { SupplierId = 2, ProductId = 4, Price = 10M},
                new ProductSupplierPrice() { SupplierId = 2, ProductId = 5, Price = 14M},
                new ProductSupplierPrice() { SupplierId = 2, ProductId = 6, Price = 6M},
                new ProductSupplierPrice() { SupplierId = 3, ProductId = 1, Price = 7M},
                new ProductSupplierPrice() { SupplierId = 3, ProductId = 3, Price = 5M},
                new ProductSupplierPrice() { SupplierId = 3, ProductId = 4, Price = 13M},
                new ProductSupplierPrice() { SupplierId = 3, ProductId = 7, Price = 15M},
                new ProductSupplierPrice() { SupplierId = 3, ProductId = 8, Price = 13M},
            };
            _context.AttachRange(productSupplierPriceList);
            await _context.SaveChangesAsync();
        }
    }
}
