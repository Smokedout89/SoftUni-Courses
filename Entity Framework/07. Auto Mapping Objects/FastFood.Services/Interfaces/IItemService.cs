namespace FastFood.Services.Interfaces;

using Models.Items;

public interface IItemService
{
    Task Add(CreateItemDTO dto);

    Task<ICollection<ListItemDTO>> GetAll();
}