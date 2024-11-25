using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.Data;
using BL.Repos;
using Model;
using Xunit;
using TaskStatus = Model.TaskStatus;

namespace Backend.Tests.Repos;

public class AllModelsServiceTest
{
    private readonly BackendDbContext _context;

    public AllModelsServiceTest()
    {
        _context = new BackendDbContext();
    }

    [Fact]
    public async Task AddUserTest()
    {
        var userService = new ProjectService<User>(_context);
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser",
            Email = "testuser@example.com",
            PasswordHash = "hashedpassword"
        };

        userService.Add(user);
        _context.SaveChanges();

        var dbUser = await _context.Users.FindAsync(user.UserId);
        Assert.NotNull(dbUser);
        Assert.Equal(user.UserId, dbUser.UserId);

        // Teardown
        userService.Delete(user);
        _context.SaveChanges();
    }

    [Fact]
    public async Task AddProjectTest()
    {
        // First create a user to be the manager
        var userService = new ProjectService<User>(_context);
        var manager = new User
        {
            UserId = Guid.NewGuid(),
            Username = "manager",
            Email = "manager@example.com",
            PasswordHash = "hashedpassword"
        };
        userService.Add(manager);
        await _context.SaveChangesAsync();

        var projectService = new ProjectService<Project>(_context);
        var project = new Project
        {
            Name = "Test Project",
            Description = "A test project",
            Status = ProjectStatus.NotStarted,
            Manager = manager
        };

        projectService.Add(project);
        await _context.SaveChangesAsync();

        var dbProject = await _context.Projects.FindAsync(project.Id);
        Assert.NotNull(dbProject);
        Assert.Equal(project.Name, dbProject.Name);

        // Teardown
        projectService.Delete(project);
        userService.Delete(manager);
        await _context.SaveChangesAsync();
    }

    [Fact]
    public async Task AddTaskEntriesTest()
    {
        // First create a user
        var userService = new ProjectService<User>(_context);
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser",
            Email = "testuser@example.com",
            PasswordHash = "hashedpassword"
        };
        userService.Add(user);
        await _context.SaveChangesAsync();

        // Then create a project
        var projectService = new ProjectService<Project>(_context);
        var project = new Project
        {
            Name = "Test Project",
            Description = "Test Description",
            Status = ProjectStatus.NotStarted,
            Manager = user
        };
        projectService.Add(project);
        await _context.SaveChangesAsync();

        // Now create the task entry
        var taskEntriesService = new ProjectService<TaskEntries>(_context);
        var taskEntry = new TaskEntries
        {
            Title = "Test Task",
            Description = "A test task entry",
            Status = TaskStatus.NotStarted,
            UserId = user.UserId,
            ProjectId = project.Id,
            User = user,
            Project = project
        };

        taskEntriesService.Add(taskEntry);
        await _context.SaveChangesAsync();

        var dbTaskEntry = await _context.Tasks.FindAsync(taskEntry.Id);
        Assert.NotNull(dbTaskEntry);
        Assert.Equal(taskEntry.Title, dbTaskEntry.Title);

        // Teardown - delete in reverse order of creation
        taskEntriesService.Delete(taskEntry);
        projectService.Delete(project);
        userService.Delete(user);
        await _context.SaveChangesAsync();
    }

    [Fact]
    public async Task AddTimeEntriesTest()
    {
        // First create a user
        var userService = new ProjectService<User>(_context);
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "testuser",
            Email = "testuser@example.com",
            PasswordHash = "hashedpassword"
        };
        userService.Add(user);
        _context.SaveChanges();

        // Then create a project
        var projectService = new ProjectService<Project>(_context);
        var project = new Project
        {
            Name = "Test Project",
            Description = "Test Description",
            Status = ProjectStatus.NotStarted,
            Manager = user
        };
        projectService.Add(project);
        _context.SaveChanges();

        // Create a task entry
        var taskEntriesService = new ProjectService<TaskEntries>(_context);
        var taskEntry = new TaskEntries
        {
            Title = "Test Task",
            Description = "Test Description",
            Status = TaskStatus.NotStarted,
            UserId = user.UserId,
            ProjectId = project.Id,
            User = user,
            Project = project
        };
        taskEntriesService.Add(taskEntry);
        _context.SaveChanges();

        // Finally create the time entry
        var timeEntriesService = new ProjectService<TimeEntries>(_context);
        var timeEntry = new TimeEntries
        {
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(1),
            Duration = TimeSpan.FromHours(1),
            UserId = user.UserId,
            User = user,
            TaskEntries = taskEntry
        };

        timeEntriesService.Add(timeEntry);
        _context.SaveChanges();

        var dbTimeEntry = await _context.Times.FindAsync(timeEntry.Id);
        Assert.NotNull(dbTimeEntry);
        Assert.Equal(timeEntry.Duration, dbTimeEntry.Duration);

        // Teardown - delete in reverse order of creation
        timeEntriesService.Delete(timeEntry);
        taskEntriesService.Delete(taskEntry);
        projectService.Delete(project);
        userService.Delete(user);
        _context.SaveChanges();
    }
}