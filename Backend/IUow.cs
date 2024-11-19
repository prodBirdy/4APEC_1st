using Model;

namespace BL;

public class IUow : IDisposable
{
    IProjectService<User> Users { get; }
    
    
    public void Dispose()
    {
        // TODO release managed resources here
    }
}