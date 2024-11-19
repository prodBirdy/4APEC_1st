using BL.Data;
using Model;

namespace BL;

public class Uow
{
    private readonly BackendDbContext _context;
    private ProjectService<User> _userRepository;
    private ProjectService<Project> _projectRepository;
    private ProjectService<TaskEntries> _taskRepository;
    private ProjectService<TimeEntries> _timeEntryRepository;

    /// <summary>
    /// Initializes a new instance of the UnitOfWork class.
    /// </summary>
    public Uow()
    {
        _context = new BackendDbContext();
    }

    /// <summary>
    /// Gets the user repository.
    /// </summary>
    public ProjectService<User> Users => _userRepository ??= new ProjectService<User>(_context);

    public ProjectService<Project> Projects => _projectRepository ??= new ProjectService<Project>(_context);

    public ProjectService<TaskEntries> Tasks => _taskRepository ??= new ProjectService<TaskEntries>(_context);

    public ProjectService<TimeEntries> Times => _timeEntryRepository ??= new ProjectService<TimeEntries>(_context);

    /// <summary>
    /// Completes the DB transactions.
    /// </summary>
    /// <returns>The number of affected records.</returns>
    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}