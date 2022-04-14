using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Data;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;
public class CategoryManager : ICategoryService
{
    CategoryValidator validator= new CategoryValidator();
    ICategoryDal _category;

    public CategoryManager(ICategoryDal category)
    {
        _category = category;
    }

    public IResult Add(Category category)
    {
        ValidationResult result = validator.Validate(category);
        if (result.IsValid)
        {
            _category.Insert(category);
            return new SuccessResult();
        }
        else
        {
            string errors = "";
            foreach (var error in result.Errors)
            {
                errors += " " + error;
            }
            return new ErrorResult(errors);
        }


    }

    public IResult Update(Category category)
    {
        ValidationResult result = validator.Validate(category);
        if (result.IsValid)
        {
            _category.Update(category);
            return new SuccessResult();
        }
        else
        {
            string errors = "";
            foreach (var error in result.Errors)
            {
                errors += " " + error;
            }
            return new ErrorResult(errors);
        }

    }

    public IResult Delete(int id)
    {
        var result = _category.Get(id);
        if (result!=null)
        {
            _category.Delete(id);
            return new SuccessResult();
        }
        else
        {
            return new ErrorResult("Bu ID mevcut değil.");
        }


    }

    public IDataResult<Category?> Get(int id)
    {
        var result = _category.Get(id);
        if (result!=null)
        {
            return new SuccessDataResult<Category?>(result);
        }
        else
        {
            return new ErrorDataResult<Category?>("Bu ID mevcut değil.");
        }

    }

    public IDataResult<IEnumerable<Category>> GetAll()
    {
        return new SuccessDataResult<IEnumerable<Category>>(_category.GetAll());
    }
}
