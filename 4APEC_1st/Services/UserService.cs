// Services/UserService.cs

using System.Security.Cryptography;
using System.Text;
using BL;
using Model;


namespace APEC_INF.Services;

/// <summary>
/// Service for managing users.
/// </summary>
public class UserService
{
    private readonly Uow _unitOfWork;

    public UserService(Uow unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Registers a new user with the given username, password, and role.
    /// </summary>
    /// <returns>True if registration is successful, false otherwise.</returns>
    public Task<bool> Register(string username, string password, string email)
    {
        if (_unitOfWork.Users.GetAll().Any(u => u.Username == username))
            return Task.FromResult(false);

        var id = Guid.NewGuid();
        var user = new User
        {
            UserId = id,
            Username = username,
            Email = email,
            PasswordHash = GenerateHash(password, id, out _),
        };

        _unitOfWork.Users.Add(user);
        _unitOfWork.Complete();
        return Task.FromResult(true);
    }

    /// <summary>
    /// Logs in a user with the given username and password.
    /// </summary>
    /// <returns>True if login is successful, false otherwise.</returns>
    public async Task<bool> Login(string username, string password)
    {
        var user = _unitOfWork.Users.GetAll().SingleOrDefault(u => u.Username == username);
        if (user == null)
            return false;

        var hash = GenerateHash(password, user.UserId, out _);
        return hash == user.PasswordHash;
    }

    /// <summary>
    /// Generates a hash for the given password and user ID.
    /// </summary>
    /// <returns>The generated hash.</returns>
    private string GenerateHash(string password, Guid userId, out string salt)
    {
        salt = new string(userId.ToString().Skip(5).Take(10).ToArray());
        using var sha512 = SHA512.Create();
        var saltedPassword = Encoding.UTF8.GetBytes(password + salt);
        var hash = sha512.ComputeHash(saltedPassword);
        for (int i = 0; i < 99; i++)
        {
            hash = sha512.ComputeHash(hash);
        }

        return Convert.ToBase64String(hash);
    }
}