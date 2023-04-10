namespace CarDealer;

using System.ComponentModel.DataAnnotations;

using Data;
using Models;
using DTOs.Export;
using DTOs.Import;

using AutoMapper;
using Newtonsoft.Json;
using AutoMapper.QueryableExtensions;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext dbContext = new CarDealerContext();

        //string inputJson = File.ReadAllText("../../../Datasets/cars.json");

        //dbContext.Database.EnsureDeleted();
        //dbContext.Database.EnsureCreated();

        //Console.WriteLine($"Database copy created!");

        string json = GetCarsFromMakeToyota(dbContext);
        File.WriteAllText("../../../Results/toyota-cars.json", json);
    }

    private static Mapper Mapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        });

        return new Mapper(config);
    }

    private static bool IsValid(object obj)
    {
        var validationContext = new ValidationContext(obj);
        var validationResult = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult);

        return isValid;
    }

    // Problem 09
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        SupplierDto[] suppDtos =
            JsonConvert.DeserializeObject<SupplierDto[]>(inputJson)!;

        ICollection<Supplier> suppliers = new List<Supplier>();

        foreach (var suppliersDto in suppDtos)
        {
            if (!IsValid(suppliersDto))
            {
                continue;
            }

            Supplier supplier = Mapper().Map<Supplier>(suppliersDto);
            suppliers.Add(supplier);
        }

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Count}.";
    }

    // Problem 10
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        PartDto[] partDto =
            JsonConvert.DeserializeObject<PartDto[]>(inputJson)!;

        ICollection<Part> parts = new List<Part>();

        foreach (var partsDto in partDto)
        {
            if (!context.Suppliers.Any(s => s.Id == partsDto.SupplierId))
            {
                continue;
            }

            Part part = Mapper().Map<Part>(partsDto);
            parts.Add(part);
        }

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}.";
    }

    // Problem 11
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        CarDto[] carDto =
            JsonConvert.DeserializeObject<CarDto[]>(inputJson)!;

        ICollection<Car> cars = new List<Car>();
        var partIds = context.Parts
            .Select(p => p.Id);

        foreach (var dto in carDto)
        {
            Car car = Mapper().Map<Car>(dto);

            foreach (var partId in dto.PartsId.Distinct())
            {
                if (partIds.Contains(partId))
                {
                    car.PartsCars.Add(new PartCar
                    {
                        PartId = partId,
                        Car = car
                    });
                }
            }

            cars.Add(car);
        }

        context.Cars.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}.";
    }

    // Problem 12
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        CustomerDto[] customerDtos =
            JsonConvert.DeserializeObject<CustomerDto[]>(inputJson)!;

        ICollection<Customer> customers = new List<Customer>();

        foreach (var customerDto in customerDtos)
        {
            Customer customer = Mapper().Map<Customer>(customerDto);
            customers.Add(customer);
        }

        //var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson)!;

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Count}.";
    }

    // Problem 13
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson)!;

        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Length}.";
    }

    // Problem 14
    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var customers = context
            .Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .ProjectTo<OrderedCustomersDto>(Mapper().ConfigurationProvider)
            .ToArray();

        string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
        return json;
    }

    // Problem 15
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        var toyotaCars = context
            .Cars
            .Where(m => m.Make == "Toyota")
            .OrderBy(m => m.Model)
            .ThenByDescending(d => d.TraveledDistance)
            .ProjectTo<ToyotaCarsDto>(Mapper().ConfigurationProvider)
            .ToArray();

        string json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
        return json;
    }

    // Problem 16
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var localSuppliers = context
            .Suppliers
            .Where(s => !s.IsImporter)
            .ProjectTo<LocalSupplierDto>(Mapper().ConfigurationProvider)
            .ToArray();

        string json = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
        return json;
    }

    // Problem 17
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var carsWithTheirListOfParts = context
            .Cars
            .Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    TraveledDistance = c.TraveledDistance,
                },
                parts = c.PartsCars
                    .Select(p => new
                    {
                        p.Part.Name,
                        Price = p.Part.Price.ToString("f2")
                    })
                    .ToArray()
            })
            .ToArray();

        var json = JsonConvert.SerializeObject(carsWithTheirListOfParts, Formatting.Indented);
        return json;
    }

    // Problem 18
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customerTotalSales = context
            .Customers
            .Where(c => c.Sales.Count > 0)
            .Select(c => new
            {
                fullName = c.Name,
                boughtCars = c.Sales.Count,
                spentMoney = c.Sales
                    .SelectMany(s => s.Car.PartsCars)
                    .Sum(p => p.Part.Price)
            })
            .OrderByDescending(c => c.spentMoney)
            .ThenByDescending(c => c.boughtCars)
            .ToArray();

        string json = JsonConvert.SerializeObject(customerTotalSales, Formatting.Indented);
        return json;
    }

    // Problem 19
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var carsWithDiscount = context
            .Sales
            .Select(s => new
            {
                car = new
                {
                    s.Car.Make,
                    s.Car.Model,
                    s.Car.TraveledDistance
                },
                customerName = s.Customer.Name,
                discount = $"{s.Discount:f2}",
                price = $"{s.Car.PartsCars.Sum(p => p.Part.Price):f2}",
                priceWithDiscount =
                    $"{s.Car.PartsCars.Sum(p => p.Part.Price) - s.Car.PartsCars.Sum(p => p.Part.Price) * s.Discount / 100:f2}"
            })
            .Take(10)
            .ToArray();

        string json = JsonConvert.SerializeObject(carsWithDiscount, Formatting.Indented);
        return json;
    }
}