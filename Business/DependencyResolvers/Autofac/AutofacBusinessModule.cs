using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Data;
using DataAccess.DbAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac;
public class AutofacBusinessModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SqlDataAccess>().As<ISqlDataAccess>().SingleInstance();

        builder.RegisterType<ArticleData>().As<IArticleDal>().SingleInstance();
        builder.RegisterType<ArticleManager>().As<IGenericBusinessService<Article>>().SingleInstance();

        builder.RegisterType<CategoryData>().As<ICategoryDal>().SingleInstance();
        builder.RegisterType<CategoryManager>().As<IGenericBusinessService<Category>>().SingleInstance();

    }
}
