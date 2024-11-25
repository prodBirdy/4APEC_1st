namespace BL.Repos;

public interface IProjectService<T> where T : class
{
    T Get(string id);
    IQueryable<T> GetAll();
    bool Add(T entity);
    bool Update(T entity);
    bool Delete(T entity);
}