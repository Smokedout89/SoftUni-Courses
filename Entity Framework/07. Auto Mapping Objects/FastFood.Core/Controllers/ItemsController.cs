namespace FastFood.Web.Controllers
{
    using System;
    using AutoMapper;
    using ViewModels.Items;
    using Services.Interfaces;
    using Services.Models.Items;
    using Microsoft.AspNetCore.Mvc;
    using Services.Models.Categories;

    public class ItemsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IItemService itemService;
        private readonly ICategoryService categoryService;

        public ItemsController(IMapper mapper, ICategoryService categoryService, IItemService itemService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.itemService = itemService;
        }

        public async Task<IActionResult> Create()
        {
            ICollection<ListCategoryDTO> categories = await categoryService.GetAll();
            IList<CreateItemViewModel> itemsVM = new List<CreateItemViewModel>();

            foreach (var category in categories)
            {
                itemsVM.Add(mapper.Map<CreateItemViewModel>(category));
            }

            return View(itemsVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", "Items");
            }

            bool validCategory = await categoryService.ExistById(model.CategoryId);

            if (!validCategory)
            {
                return RedirectToAction("Create", "Items");
            }

            CreateItemDTO itemDto = mapper.Map<CreateItemDTO>(model);
            await itemService.Add(itemDto);

            return RedirectToAction("All", "Items");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListItemDTO> itemDtos = await itemService.GetAll();
            IList<ItemsAllViewModels> itemVms = new List<ItemsAllViewModels>();

            foreach (var item in itemDtos)
            {
                itemVms.Add(mapper.Map<ItemsAllViewModels>(item));
            }

            return View(itemVms);
        }
    }
}
