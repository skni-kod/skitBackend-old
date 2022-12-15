using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using skitBackend.Data.Models.Dto;

namespace skitBackend.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AccountService(ApiDbContext dbContext, IPasswordHasher<User> passwordHasher) 
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public void RegisterUser(RegisterUserDto registerUserDto) 
        {
            var newUser = new User()
            {
                Login = registerUserDto.Login,
                Nickname = registerUserDto.Nickname,
                Email = registerUserDto.Email,
            };
            newUser.Password = _passwordHasher.HashPassword(newUser, registerUserDto.Password);

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
