using BlogApi.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : CrudController<Category, CategoryModel>
{
    public CategoriesController(IGenericBusinessService<Category> crudService) : base(crudService)
    {
    }
}
