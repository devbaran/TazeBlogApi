using DataAccess.DbAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class ArticleData : IArticleDal
{
    ISqlDataAccess _db;

    public ArticleData(ISqlDataAccess db)
    {
        _db = db;
    }

    public IEnumerable<Article> GetAll() =>
        _db.LoadData<Article, dynamic>(storedProcedure: "dbo.spArticle_GetAll", new { });

    public Article? Get(int id)
    {
        var results = _db.LoadData<Article, dynamic>("dbo.spArticle_Get", new { Id = id });
        return results.FirstOrDefault();
    }

    public void Insert(Article article) =>
        _db.SaveData("dbo.spArticle_Insert", new { article.CategoryId, article.Title, article.Content, article.CreationDate, article.Status });

    public void Update(Article article) =>
        _db.SaveData("dbo.spArticle_Update", article);

    public void Delete(int id) =>
        _db.SaveData("dbo.spArticle_Delete", new { Id = id });
}
