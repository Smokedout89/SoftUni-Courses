namespace FastFood.Web.MappingConfiguration
{
    using Models;
    using AutoMapper;
    using Services.Models.Categories;
    using Services.Models.Items;
    using ViewModels.Categories;
    using ViewModels.Items;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            // Categories
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CreateCategoryInputModel, CreateCategoryDTO>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));
            CreateMap<Category, ListCategoryDTO>();
            CreateMap<ListCategoryDTO, CategoryAllViewModel>();

            // Item
            CreateMap<ListCategoryDTO, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));
            CreateMap<CreateItemInputModel, CreateItemDTO>();
            CreateMap<CreateItemDTO, Item>();
            CreateMap<Item, ListItemDTO>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));
            CreateMap<ListItemDTO, ItemsAllViewModels>();

        }
    }
}
