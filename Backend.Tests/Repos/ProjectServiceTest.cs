using APEC_INF.Data;
using BL.Data;
using BL.Repos;
using JetBrains.Annotations;
using Model;
using Xunit;

namespace Backend.Tests.Repos;

[TestSubject(typeof(ProjectService<User>))]

public class ProjectServiceTest
{
    BackendDbContext context = new BackendDbContext();


    [Fact()]
    public void AddUserTest()
    {
        ProjectService<User> uService = new ProjectService<User>(context);
        
        User user = new User();
        user.Username = "test";
        user.PasswordHash = "test";
        user.Email = "test@test.com";
        uService.Add(user);
        Assert.Equal(user, context.Users.Find(user.Username));
        context.Users.Remove(user);
        context.SaveChanges();
        
    }
    
    
}