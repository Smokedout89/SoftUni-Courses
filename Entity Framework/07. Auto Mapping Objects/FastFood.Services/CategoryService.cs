namespace FastFood.Services
{
    using Data;
    using Interfaces;
    using AutoMapper;
    using FastFood.Models;
    using Models.Categories;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;

    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task Add(CreateCategoryDTO categoryDTO)
        {
            Category category = this.mapper.Map<Category>(categoryDTO);

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ListCategoryDTO>> GetAll()
        {
            ICollection<ListCategoryDTO> result = await this.dbContext
                .Categories
                .ProjectTo<ListCategoryDTO>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

        public async Task<bool> ExistById(int id)
        {
            return await dbContext
                .Categories
                .AnyAsync(c => c.Id == id);
        }
    }
}