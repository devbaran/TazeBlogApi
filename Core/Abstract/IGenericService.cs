﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract;
public interface IGenericService<T>
{
    void Insert(T entity);
    void Update(T entity);
    void Delete(int id);
    IEnumerable<T> GetAll();
    T? Get(int id);

}