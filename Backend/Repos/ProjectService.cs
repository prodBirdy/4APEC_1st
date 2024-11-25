using BL.Data;
using Microsoft.EntityFrameworkCore;

namespace BL.Repos;

/// <summary>
/// Generic repository class that provides basic CRUD operations for any entity class in the project.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public class ProjectService<T> : IProjectService<T> where T : class
{
    private readonly BackendDbContext _context;
    private readonly DbSet<T> _dbSet;

    /// <summary>
    /// Initializes a new instance of the Repository class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public ProjectService(BackendDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    public T Get(string id)
    {
        return _dbSet.Find(id);
    }

    /// <summary>
    /// Retrieves all entities of a certain type.
    /// </summary>
    /// <returns>A queryable collection of entities.</returns>
    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    /// <summary>
    /// Adds a new entity to the database.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    /// <summary>
    /// Updates an existing entity in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}