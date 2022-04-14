using DataAccess.DbAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class CategoryData : ICategoryDal
{
    ISqlDataAccess _db;

    public CategoryData(ISqlDataAccess db)
    {
        _db = db;
    }

    public IEnumerable<Category> GetAll() =>
        _db.LoadData<Category, dynamic>(storedProcedure: "dbo.spCategory_GetAll", new { });

    public Category? Get(int id)
    {
        var results = _db.LoadData<Category, dynamic>("dbo.spCategory_Get", new { Id = id });
        return results.FirstOrDefault();
    }

    public void Insert(Category category) =>
        _db.SaveData("dbo.spCategory_Insert", new { category.Name, category.Description, category.Status });

    public void Update(Category category) =>
        _db.SaveData("dbo.spCategory_Update", category);

    public void Delete(int id) =>
        _db.SaveData("dbo.spCategory_Delete", new { Id = id });
}
