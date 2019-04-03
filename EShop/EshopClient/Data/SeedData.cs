using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopClient.Data
{
    public static class SeedData
    {
        public static void Initialize(ShopContext _context)
        {
            #region Categories
            _context.Categories.AddRange(
                new Category()
                {
                    Name = "Møbler"
                },
                new Category()
                {
                    Name = "Borde",
                    ParentCategoryId = 1
                },
                new Category()
                {
                    Name = "Spiseborde",
                    ParentCategoryId = 2
                },
                new Category()
                {
                    Name = "Sofaborde",
                    ParentCategoryId = 2
                },
                new Category()
                {
                    Name = "Stole"
                },
                new Category()
                {
                    Name = "Spisestole",
                    ParentCategoryId = 5
                },
                new Category()
                {
                    Name = "Lænestole",
                    ParentCategoryId = 5
                },
                new Category()
                {
                    Name = "Tilbehør"
                },
                new Category ()
                {
                    Name = "Tæpper",
                    ParentCategoryId = 8
                },
                new Category()
                {
                    Name = "Puder",
                    ParentCategoryId = 8
                },
                new Category()
                {
                    Name = "2 Personers",
                    ParentCategoryId = 3
                },
                new Category()
                {
                    Name = "4 Personers",
                    ParentCategoryId = 3
                },
                new Category()
                {
                    Name = "6 Personers",
                    ParentCategoryId = 3
                }
                );
            #endregion
            #region Manufacturers
            _context.Manufacturers.AddRange(
                new Manufacturer()
                {
                    Name = "Stol.dk"
                },
                new Manufacturer()
                {
                    Name = "Bordet A/S"
                },
                new Manufacturer()
                {
                    Name = "BordTing"
                },
                new Manufacturer()
                {
                    Name = "Puder & Tæpper"
                },
                new Manufacturer()
                {
                    Name = "Moebeller"
                }
                );
            #endregion
            #region Suppliers
            _context.Suppliers.AddRange(
                new Supplier()
                {
                    Name = "Idé Møbler",
                    ContactInfo = new ContactInfo()
                    {
                        Country = "Denmark",
                        City = "Sønderborg",
                        Zip = "6400",
                        Street = "Bygade 01",
                        Email = "info@idemobler.dk",
                        Phone = "12345678"
                    }
                },
                new Supplier()
                {
                    Name = "MyHome",
                    ContactInfo = new ContactInfo()
                    {
                        Country = "Denmark",
                        City = "Sønderborg",
                        Zip = "6400",
                        Street = "Bygade 01",
                        Email = "info@myhome.dk",
                        Phone = "12345678"
                    }
                },
                new Supplier()
                {
                    Name = "Jysk",
                    ContactInfo = new ContactInfo()
                    {
                        Country = "Denmark",
                        City = "Sønderborg",
                        Zip = "6400",
                        Street = "Bygade 01",
                        Email = "info@jysk.dk",
                        Phone = "12345678"
                    }
                },
                new Supplier()
                {
                    Name = "Deutsche Dinge",
                    ContactInfo = new ContactInfo()
                    {
                        Country = "Germany",
                        City = "Kiel",
                        Zip = "24505",
                        Street = "Strasse 2",
                        Email = "info@dd.de",
                        Phone = "12345678"
                    }
                }
                );
            #endregion
            _context.Products.AddRange(
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Karl Johan",
                    ManufacturerId = 1,
                    UnitPrice = 449.95M,
                    Summary = "Farverig stol til enhver anledning",
                    Description = "",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Thorleif",
                    ManufacturerId = 5,
                    UnitPrice = 1999.95M,
                    Summary = "Flot stol i eksklusivt design",
                    Description = "En stol der er alle pengene værd",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 2,
                    UnitPrice = 1799.95M,
                    Summary = "Spisebord",
                    Description = "",
                    CategoryId = 3,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Hans",
                    ManufacturerId = 1,
                    UnitPrice = 799.95M,
                    Summary = "Simpel stol, let at anvende",
                    Description = "Denne spisestol fra producenten Stol.dk kan både bruges til at sidde på, og til at stå på",
                    CategoryId = 6,
                });
        }
    }
}
