    namespace ProductShop;

using Models;
using AutoMapper;
using DTOs.Export;
using DTOs.Import;

public class ProductShopProfile : Profile
{
    public ProductShopProfile()
    {
        CreateMap<UserDto, User>();
        CreateMap<ProductDto, Product>();
        CreateMap<CategoryDto, Category>();
        CreateMap<CategoryProductDto, CategoryProduct>();

        CreateMap<Product, ProductsInRangeDto>()
            .ForMember(d => d.Seller, mo => mo
                .MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

        // Inner DTO
        CreateMap<Product, UserSoldProductsDto>();
            //.ForMember(d => d.BuyerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
            //.ForMember(d => d.BuyerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));
        // Outer DTO
        CreateMap<User, UsersWithSoldProductsDto>()
            .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s.ProductsSold
                .Where(p => p.BuyerId.HasValue)));

        CreateMap<Category, CategoriesByProductDto>()
            .ForMember(d => d.Category, 
                mo => mo.MapFrom(s => s.Name))
            .ForMember(d => d.ProductsCount, 
                mo => mo.MapFrom(s => s.CategoriesProducts.Count))
            .ForMember(d => d.AveragePrice, 
                mo => mo.MapFrom(s => Math.Round((double)s.CategoriesProducts.Average(p => p.Product.Price), 2)))
            .ForMember(d => d.TotalRevenue, 
                mo => mo.MapFrom(s => Math.Round((double)s.CategoriesProducts.Sum(p => p.Product.Price), 2)));
    }
}