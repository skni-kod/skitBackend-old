﻿using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Data;
using Data.Models;
using skitBackend.Data.Models.Dto;
using skitBackend.Exceptions;

namespace skitBackend.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string LoginUser(LoginUserDto dto);
    }
    
    public class AccountService : IAccountService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(ApiDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings) 
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public void RegisterUser(RegisterUserDto registerUserDto) 
        {
            var nickname = registerUserDto.Nickname != "" ? registerUserDto.Nickname : registerUserDto.Login;
            var newUser = new User()
            {
                Login = registerUserDto.Login,
                Nickname = nickname,
                Email = registerUserDto.Email,
            };
            newUser.Password = _passwordHasher.HashPassword(newUser, registerUserDto.Password);

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public string LoginUser(LoginUserDto loginUserDto)
        {
            var user = _dbContext.Users
                .FirstOrDefault(user => user.Login == loginUserDto.Login);

            if (user is null)
                throw new BadRequestException("Wrong username or password!");

            var result = _passwordHasher
                .VerifyHashedPassword(user, user.Password, loginUserDto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new BadRequestException("Wrong username or password!");

            return GenerateJwt(user);
        }

        public string GenerateJwt(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Nickname}"),
                new Claim(ClaimTypes.Email, $"{user.Email}")
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
