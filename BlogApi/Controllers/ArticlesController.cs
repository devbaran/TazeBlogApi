using BlogApi.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ArticlesController : CrudController<Article,ArticleModel>
{
    public ArticlesController(IGenericBusinessService<Article> crudService) : base(crudService)
    {
    }
}
