using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Data;
using Data.Models;
using skitBackend.Data.Models.Dto;
using skitBackend.Exceptions;
using Microsoft.AspNetCore.Authorization;
using skitBackend.Authorization;
using Microsoft.EntityFrameworkCore;

namespace skitBackend.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string LoginUser(LoginUserDto dto);
        void DeleteUser(int id);
        void EditUser(EditUserDto editUserDto);
    }
    
    public class AccountService : IAccountService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public AccountService(ApiDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IAuthorizationService authorizationService, IUserContextService userContextService) 
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public void RegisterUser(RegisterUserDto registerUserDto) 
        {
            var nickname = registerUserDto.Nickname != "" ? registerUserDto.Nickname : registerUserDto.Login;
            var newUser = new User()
            {
                Login = registerUserDto.Login,
                Nickname = nickname,
                Email = registerUserDto.Email,
                UserRole = (Data.Enums.UserRoleEnum)registerUserDto.UserRole
            };
            newUser.Password = _passwordHasher.HashPassword(newUser, registerUserDto.Password);

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public string LoginUser(LoginUserDto loginUserDto)
        {
            var user = _dbContext.Users
                .FirstOrDefault(user => user.Login == loginUserDto.Login && user.IsDeleted == false);

            if (user is null)
                throw new BadRequestException("Wrong username or password!");

            var result = _passwordHasher
                .VerifyHashedPassword(user, user.Password, loginUserDto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new BadRequestException("Wrong username or password!");

            return _GenerateJwt(user);
        }

        public void DeleteUser(int id)
        {
            var userToDelete = _dbContext.Users
                .FirstOrDefault(user => user.Id == id && user.IsDeleted == false);

            if(userToDelete is null)
                throw new NotFoundException("User not found");

            var authorizationResult = _authorizationService.AuthorizeAsync(
                _userContextService.User, 
                userToDelete, 
                new UserResourceOperationRequirement(UserResourceOperation.Delete)).Result;

            if(!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            userToDelete.IsDeleted = true;
            _dbContext.Users.Update(userToDelete);
            _dbContext.SaveChanges();
        }

        public void EditUser(EditUserDto editUserDto) 
        {
            var user = _dbContext.Users
                .FirstOrDefault(user => user.Id == editUserDto.Id && user.IsDeleted == false);

            if(user is null)
                throw new NotFoundException("User not found");

            var authorizationResult = _authorizationService.AuthorizeAsync(
                _userContextService.User,
                user,
                new UserResourceOperationRequirement(UserResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            user.Nickname = editUserDto.Nickname ?? user.Nickname;
            user.DiscordNickname = editUserDto.DiscordNickname ?? user.DiscordNickname;
            user.Email = editUserDto.Email ?? user.Email;

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        private string _GenerateJwt(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Nickname}"),
                new Claim(ClaimTypes.Role, $"{(int)user.UserRole}"),
                new Claim(ClaimTypes.Email, $"{user.Email}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred
                );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenStr;
        }
    }
}
