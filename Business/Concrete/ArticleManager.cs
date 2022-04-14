using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Data;
using DataAccess.DbAccess;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        ArticleValidator validator = new ArticleValidator();
        IArticleDal _article;

        public ArticleManager(IArticleDal article)
        {
            _article = article;
        }

        public IResult Add(Article article)
        {
            ValidationResult result = validator.Validate(article);
            
            if (result.IsValid)
            {
                _article.Insert(article);
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

        public IResult Update(Article article)
        {

            ValidationResult result = validator.Validate(article);

            if (result.IsValid)
            {
                _article.Update(article);
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
            var result = _article.Get(id);
            if (result!=null)
            {
                _article.Delete(id);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult("Bu ID mevcut değil.");
            }
            

        }

        public IDataResult<Article?> Get(int id)
        {
            var result = _article.Get(id);
            if (result!=null)
            {
                return new SuccessDataResult<Article?>(result);

            }
            else
            {
                return new ErrorDataResult<Article?>("Bu ID mevcut değil.");
            }
        }

        public IDataResult<IEnumerable<Article>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Article>>(_article.GetAll());
        }
    }
}
