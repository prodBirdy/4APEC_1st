using System;
using System.Linq;
using System.Linq.Expressions;

public interface IProjectService<T> where T : class
{
    T Get(Guid id);
    IQueryable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}