namespace ProductShop;

using System.ComponentModel.DataAnnotations;

using Data;
using Models;
using DTOs.Export;
using DTOs.Import;

using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper.QueryableExtensions;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext dbContext = new ProductShopContext();

        //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

        //dbContext.Database.EnsureDeleted();
        //dbContext.Database.EnsureCreated();

        //Console.WriteLine($"Database copy created!");

        string json = GetCategoriesByProductsCount(dbContext);
        File.WriteAllText("../../../Results/categories-by-products.json", json);
    }

    private static Mapper Mapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
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

    // Problem 01
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        UserDto[] userDtos =
            JsonConvert.DeserializeObject<UserDto[]>(inputJson)!;

        ICollection<User> users = new List<User>();

        foreach (var userDto in userDtos)
        {
            if (!IsValid(userDto))
            {
                continue;
            }

            User user = Mapper().Map<User>(userDto);
            users.Add(user);
        }

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Count}";
    }

    // Problem 02
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        ProductDto[] productDtos =
            JsonConvert.DeserializeObject<ProductDto[]>(inputJson)!;

        ICollection<Product> products = new List<Product>();

        foreach (var productDto in productDtos)
        {
            if (!IsValid(productDto))
            {
                continue;
            }

            Product product = Mapper().Map<Product>(productDto);
            products.Add(product);
        }

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Count}";
    }

    // Problem 03
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        CategoryDto[] categoryDtos =
            JsonConvert.DeserializeObject<CategoryDto[]>(inputJson)!;

        ICollection<Category> categories = new List<Category>();

        foreach (var categoryDto in categoryDtos)
        {
            if (!IsValid(categoryDto))
            {
                continue;
            }

            Category category = Mapper().Map<Category>(categoryDto);
            categories.Add(category);
        }

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count}";
    }

    // Problem 04
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        CategoryProductDto[] categoryProductDtos =
            JsonConvert.DeserializeObject<CategoryProductDto[]>(inputJson)!;

        ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

        foreach (var dto in categoryProductDtos)
        {
            //if (!IsValid(dto))
            //{
            //    continue;
            //}

            CategoryProduct categoryProduct = Mapper().Map<CategoryProduct>(dto);
            categoryProducts.Add(categoryProduct);
        }

        context.CategoriesProducts.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Count}";
    }

    // Problem 05
    public static string GetProductsInRange(ProductShopContext context)
    {
        var products = context
            .Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            //.Select(p => new
            //{
            //    name = p.Name,
            //    price = p.Price,
            //    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
            //})
            .ProjectTo<ProductsInRangeDto>(Mapper().ConfigurationProvider)
            .ToArray();

        string json = JsonConvert.SerializeObject(products, Formatting.Indented);
        return json;
    }

    // Problem 06
    public static string GetSoldProducts(ProductShopContext context)
    {
        var usersSoldItems = context
            .Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .ProjectTo<UsersWithSoldProductsDto>(Mapper().ConfigurationProvider)
            .ToList();

        string json = JsonConvert.SerializeObject(usersSoldItems, Formatting.Indented);
        return json;
    }

    // Problem 07
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context
            .Categories
            .OrderByDescending(c => c.CategoriesProducts.Count)
            .ProjectTo<CategoriesByProductDto>(Mapper().ConfigurationProvider)
            .ToArray();

        string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
        return json;
    }

    // Problem 08
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context
            .Users
            .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                SoldProducts = new
                {
                    Count = u.ProductsSold.Count(p => p.Buyer != null),
                    Products = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                }
            })
            .ToArray();

        var resultDto = new
        {
            UsersCount = users.Length,
            Users = users
        };

        JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        
        string json = JsonConvert.SerializeObject(resultDto, Formatting.Indented, settings);
        return json;
    }
}