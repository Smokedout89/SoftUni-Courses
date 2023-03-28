namespace FastFood.Services.Interfaces;

using Models.Categories;

public interface ICategoryService
{
    Task Add(CreateCategoryDTO categoryDTO);

    Task<ICollection<ListCategoryDTO>> GetAll();

    Task<bool> ExistById(int id);
}