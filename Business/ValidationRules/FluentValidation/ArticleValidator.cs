using Business.Constants.FluentValidationMessages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation;
public class ArticleValidator:AbstractValidator<Article>
{
    public ArticleValidator()
    {
        RuleFor(article=> article.CategoryId).NotEmpty().WithMessage(ArticleMessages.NullId);

        RuleFor(article=> article.Title).NotEmpty().WithMessage(ArticleMessages.ArticleTitleNull);
        RuleFor(article=> article.Title).MinimumLength(4).WithMessage(ArticleMessages.ArticleTitleMinLenght);
        RuleFor(article=> article.Title).MaximumLength(140).WithMessage(ArticleMessages.ArticleTitleMaxLenght);

        RuleFor(article=> article.Content).NotEmpty().WithMessage(ArticleMessages.ArticleContentNull);
        RuleFor(article=> article.Content).MinimumLength(140).WithMessage(ArticleMessages.ArticleContentMinLenght);

        RuleFor(article=> article.CreationDate).NotEmpty().WithMessage(ArticleMessages.ArticleDateNull);

        RuleFor(article=> article.Status).NotEmpty().WithMessage(ArticleMessages.ArticleStatusNull);
    }
}
