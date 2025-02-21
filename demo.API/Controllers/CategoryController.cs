using demo.Core.Data;
using demo.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categryService;

        public CategoryController(ICategoryService categryService)
        {
            this.categryService = categryService;
        }

        [HttpGet]
        public List<Category> GetAllCategory()
        {
            return categryService.GetAllCategory();
        }
        [HttpGet]
        [Route("getbyId/{id}")]
        public Category GetCategoryById(int id)
        {

            return categryService.GetCategoryById(id);
        }

        [HttpPost]
        public void CreateCategory(Category category)
        {
            categryService.CreateCategory(category);
        }
        [HttpPut]
        public void UpdateCategory(Category category)
        {
            categryService.UpdateCategory(category);
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public void DeleteCategory(int id)
        {
            categryService.DeleteCategory(id);
        }
    }
}
