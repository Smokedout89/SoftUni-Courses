namespace CarDealer
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    using Data;
    using Models;
    using DTOs.Export;
    using DTOs.Import;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext dbContext = new CarDealerContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            //Console.WriteLine("Database Reset!");

            //string xml = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(dbContext, xml));

            string xml = GetTotalSalesByCustomer(dbContext);
            File.WriteAllText("../../../results/customers-total-sales.xml", xml);
        }

        // Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string rootName = "Suppliers";
            SupplierDto[] supplierDtos = Deserialize<SupplierDto[]>(inputXml, rootName);

            List<Supplier> suppliers = supplierDtos
                .Select(dto => new Supplier
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            string rootName = "Parts";
            PartDto[] partDtos = Deserialize<PartDto[]>(inputXml, rootName);

            List<Part> parts = partDtos
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .Select(dto => new Part
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string rootName = "Cars";
            CarDto[] carDtos = Deserialize<CarDto[]>(inputXml, rootName);

            ICollection<Car> cars = new List<Car>();

            foreach (var dto in carDtos)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                };

                ICollection<PartCar> currParts = new List<PartCar>();

                foreach (var partId in dto.Parts.Select(p => p.Id).Distinct())
                {
                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    currParts.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                car.PartsCars = currParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string rootName = "Customers";
            CustomerDto[] customerDtos = Deserialize<CustomerDto[]>(inputXml, rootName);

            List<Customer> customers = customerDtos
                .Select(dto => new Customer
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string rootName = "Sales";
            SaleDto[] saleDtos = Deserialize<SaleDto[]>(inputXml, rootName);

            List<Sale> sales = saleDtos
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .Select(dto => new Sale
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount,
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        // Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            CarWithDistanceDto[] cars = context
                .Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(m => m.Make)
                .ThenBy(m => m.Model)
                .Take(10)
                .Select(dto => new CarWithDistanceDto
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance,
                })
                .ToArray();

            return Serialize(cars, "cars");
        }

        // Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            BmwCarDto[] cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(dto => new BmwCarDto
                {
                    Id = dto.Id,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                })
                .ToArray();

            return Serialize(cars, "cars");
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            LocalSupplierDto[] locals = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .Select(dto => new LocalSupplierDto
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Parts = dto.Parts.Count
                })
                .ToArray();

            return Serialize(locals, "suppliers");
        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            CarWithPartsDto[] carParts = context
                .Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new CarWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                        .Select(pc => new PartsDto
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .ToArray();

            return Serialize(carParts, "cars");
        }

        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var temp = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SalesInfo = c.Sales.Select(s => new
                    {
                        SpentMoney = c.IsYoungDriver
                                ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                                : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                    })
                        .ToArray(),
                })
                .ToArray();

            CustomerSalesDto[] customerSales = temp
                .OrderByDescending(si => si.SalesInfo.Sum(s => s.SpentMoney))
                .Select(dto => new CustomerSalesDto
                {
                    FullName = dto.FullName,
                    BoughtCars = dto.BoughtCars,
                    SpentMoney = dto.SalesInfo.Sum(p => p.SpentMoney).ToString("f2")
                })
                .ToArray();

            return Serialize(customerSales, "customers");
        } 

        // Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            SalesDto[] sales = context
                .Sales
                .Select(dto => new SalesDto
                {
                    Car = new SaleCarDto
                    {
                        Make = dto.Car.Make,
                        Model = dto.Car.Model,
                        TraveledDistance = dto.Car.TraveledDistance
                    },
                    Discount = dto.Discount.ToString("f0"),
                    CustomerName = dto.Customer.Name,
                    Price = (double)dto.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = (double)(dto.Car.PartsCars.Sum(p => p.Part.Price) -
                                            (dto.Car.PartsCars.Sum(p => p.Part.Price) * (dto.Discount / 100)))
                })
                .ToArray();

            return Serialize(sales, "sales");
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer
                .Deserialize(reader)!;

            return dtos;
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}