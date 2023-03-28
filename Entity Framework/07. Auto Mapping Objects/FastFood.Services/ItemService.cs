namespace FastFood.Services;

using Data;
using Interfaces;
using AutoMapper;
using Models.Items;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

public class ItemService : IItemService
{
    private readonly FastFoodContext dbContext;
    private readonly IMapper mapper;

    public ItemService(FastFoodContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task Add(CreateItemDTO dto)
    {
        Item item = mapper.Map<Item>(dto);
        
        await dbContext.Items.AddAsync(item);
        await dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<ListItemDTO>> GetAll()
    {
        ICollection<ListItemDTO> itemDtos = await dbContext
            .Items
            .ProjectTo<ListItemDTO>(mapper.ConfigurationProvider)
            .ToListAsync();
        
        return itemDtos;
    }
}