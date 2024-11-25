namespace BL.Repos;

public interface IProjectService<T> where T : class
{
    T Get(string id);
    IQueryable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}