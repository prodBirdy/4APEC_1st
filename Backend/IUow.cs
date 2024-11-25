using BL.Repos;
using Model;

namespace BL;

public class IUow : IDisposable
{
    IProjectService<User> Users { get; }
    IProjectService<Project> Projects { get; }
    IProjectService<TaskEntries> Tasks { get; }
    IProjectService<TimeEntries> Times { get; }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}