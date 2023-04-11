namespace ProductShop
{
    using System.Text;
    using System.Xml.Serialization;

    using Data;
    using Models;
    using DTOs.Export;
    using DTOs.Import;

    public static class StartUp
    {
        public static void Main()
        {
            ProductShopContext dbContext = new ProductShopContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            //Console.WriteLine("Database Reset!");

            //string xml = File.ReadAllText("../../../Datasets/categories-products.xml");
            string xml = GetUsersWithProducts(dbContext);
            File.WriteAllText("../../../results/users-and-products.xml", xml);
        }
        
        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            string rootName = "Users";
            UserDto[] userDtos = Deserialize<UserDto[]>(inputXml, rootName);

            var users = userDtos
                .Select(dto => new User
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age
                })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        
        // Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            string rootName = "Products";
            ProductDto[] productDtos = Deserialize<ProductDto[]>(inputXml, rootName);

            var products = productDtos
                .Select(dto => new Product
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    SellerId = dto.SellerId,
                    BuyerId = dto.BuyerId,
                })
                .ToList();
            
            context.Products.AddRange(products);
            context.SaveChanges();
            
            return $"Successfully imported {products.Count}";
        }

        // Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            string rootName = "Categories";
            CategoryDto[] categoryDtos = Deserialize<CategoryDto[]>(inputXml, rootName);

            ICollection<Category> categories = new List<Category>();

            foreach (var dto in categoryDtos)
            {
                if (dto.Name == null!)
                {
                    continue;
                }

                categories.Add(new Category
                {
                    Name = dto.Name
                });
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            string rootName = "CategoryProducts";
            CategoryProductDto[] cpDto = Deserialize<CategoryProductDto[]>(inputXml, rootName);

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var dto in cpDto)
            {
                if (!context.Categories.Any(c => c.Id == dto.CategoryId) || 
                        !context.Products.Any(p => p.Id == dto.ProductId))
                {
                    continue;
                }
                
                categoryProducts.Add(new CategoryProduct
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId
                });
            }
            
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        
        // Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            ProductsInRangeDto[] products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .ToArray();

            return Serialize(products, "Products");
        }

        // Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            UserProductsDto[] users = context
                .Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UserProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new SoldProductsDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .ToArray();

            return Serialize(users, "Users");
        }

        // Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            CategoriesByProductsDto[] catByProducts = context
                .Categories
                .Select(cp => new CategoriesByProductsDto
                {
                    Name = cp.Name,
                    Count = cp.CategoryProducts.Count,
                    AveragePrice = cp.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = cp.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(t => t.TotalRevenue)
                .ToArray();

            return Serialize(catByProducts, "Categories");
        }

        // Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new UserInfoWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new UserSoldProductsDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Select(p => new SoldProductsDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var usersWithProducts = new UserWithProducts()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = users
            };

            return Serialize(usersWithProducts, "Users");
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