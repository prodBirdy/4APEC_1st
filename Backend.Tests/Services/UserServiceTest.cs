using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APEC_INF.Services;
using BL;
using BL.Data;
using JetBrains.Annotations;
using Model;
using Xunit;

namespace Backend.Tests.Services;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{
    BackendDbContext context = new BackendDbContext();
    Uow uow = new Uow();
    
    [Fact]
    public async Task RegisterUserTest()
    {
        UserService ust = new UserService(uow);

        var res = await ust.Register("username", "password", "email");
        Assert.True(res);
        
        // Use the same context/UoW instance to avoid tracking conflicts
        var user = uow.Users.GetAll().FirstOrDefault(u => u.Username == "username" && u.Email == "email");
        Assert.NotNull(user);
        
        // Delete using the same context that's tracking the entity
        uow.Users.Delete(user);
        uow.Complete();
    }
    [Fact]
    public async Task LoginTest()
    {
        // First register a user
        UserService ust = new UserService(uow);
        var res = await ust.Register("username", "password", "email");
        Assert.True(res);
        var user = uow.Users.GetAll().FirstOrDefault(u => u.Username == "username" && u.Email == "email");
        Assert.NotNull(user);
        // Then login
        var log = await ust.Login("username", "password");
        Assert.True(log);
        
        // Teardown
        uow.Users.Delete(user);
        uow.Complete();
    }

    
}