using System;
using System.Threading.Tasks;
using APEC_INF.Data;
using BL;
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
    Uow uow = new Uow();

    [Fact()]
    public async Task AddUserTest()
    {
        User user = new User();
        user.Username = "test";
        user.PasswordHash = "test";
        user.Email = "test@test.com";
        user.UserId = Guid.NewGuid();
        user.Email = "test@test.com";
        
        uow.Users.Add(user);
        uow.Complete();
        
        User? dbUser = await context.Users.FindAsync(user.UserId);
        Assert.NotNull(dbUser);
        Assert.Equal(user.UserId, dbUser!.UserId);
        
        // Teardown
         uow.Users.Delete(user);
         uow.Complete();
    }
    
    
    
}