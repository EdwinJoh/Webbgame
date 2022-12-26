using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service.Contracts;
using SheredHelpers;

namespace Service;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly RepositoryContext _context;

    public AuthService(RepositoryContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    /// <summary>
    ///     Logs in a user to the appication
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<ServiceResponse<string>> Login(string email, string password)
    {
        var respons = new ServiceResponse<string>();
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
        if (user == null)
        {
            respons.Success = false;
            respons.Message = " user not found.";
        }
        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            respons.Success = false;
            respons.Message = " username or password is not matching";
        }
        else
        {
            respons.Data = CreateToken(user);
        }

        return respons;
    }

    /// <summary>
    ///     This service register an user to the database.
    ///     it checks if the user email already exist or not before saving the new user.
    ///     And save the password as an hash.
    /// </summary>
    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        if (await UserExist(user.Email))
            return new ServiceResponse<int>
            {
                Success = false,
                Message = "User already exist"
            };
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return new ServiceResponse<int> { Data = user.Id, Message = "Registration Successfull" };
    }

    /// <summary>
    ///     Method that check if the user aleady exist in the database searching for the email that the user puts in.
    /// </summary>
    public async Task<bool> UserExist(string email)
    {
        if (await _context.Users.AnyAsync(user => user.Email.ToLower().Equals(email.ToLower())))
            return true;

        return false;
    }

    /// <summary>
    ///     Method that creates and set password hash and salt.
    /// </summary>
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac
                .ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    /// <summary>
    ///     This method verify the password the user puts in and hash it to match the password hash in the database.
    /// </summary>
    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHas = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHas.SequenceEqual(passwordHash);
        }
    }

    /// <summary>
    ///     Method that create an token to help the user stay login and set the login timer / token timer to expire after one
    ///     day.
    /// </summary>
    private string? CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}