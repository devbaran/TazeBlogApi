using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;
public interface IGenericBusinessService<T>
{
    IResult Add(T entity);
    IResult Delete(int id);
    IResult Update(T entity);
    IDataResult<T?> Get(int id);
    IDataResult<IEnumerable<T>> GetAll();
}
