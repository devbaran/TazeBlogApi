using Business.Abstract;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CrudController<TEntity , TEntityModel> : ControllerBase where TEntity : class
{
    private IGenericBusinessService<TEntity> _crudService;

    public CrudController(IGenericBusinessService<TEntity> crudService)
    {
        _crudService = crudService;
    }


    [HttpGet("Get/{id}")]
    public IActionResult Get(int id)
    {
        var result = _crudService.Get(id);
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }


    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var result = _crudService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }


    [HttpPost("Add")]
    public IActionResult Add(TEntityModel entityModel)
    {
        TEntity entity= entityModel.Adapt<TEntity>();

        var result = _crudService.Add(entity);
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }


    [HttpPut("Update")]
    public IActionResult Update(TEntityModel entityModel)
    {
        TEntity entity = entityModel.Adapt<TEntity>();

        var result = _crudService.Update(entity);
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }


    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _crudService.Delete(id);
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }


}

