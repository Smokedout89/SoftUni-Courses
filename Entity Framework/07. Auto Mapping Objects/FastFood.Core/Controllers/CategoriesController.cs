namespace FastFood.Web.Controllers
{
    using System;
    using AutoMapper;
    using Services.Interfaces;
    using ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;
    using Services.Models.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;   
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", "Categories");
            }

            CreateCategoryDTO categoryDTO = this.mapper.Map<CreateCategoryDTO>(model);
            await this.categoryService.Add(categoryDTO);
            
            return RedirectToAction("All", "Categories");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListCategoryDTO> categoryDtos = await this.categoryService.GetAll();
            IList<CategoryAllViewModel> categoryAll = new List<CategoryAllViewModel>();

            foreach (var dto in categoryDtos)
            {
                categoryAll.Add(mapper.Map<CategoryAllViewModel>(dto));
            }

            return View(categoryAll);
        }
    }
}
