using AutoMapper;
using ISMS_API.Data;
using ISMS_API.DTOs;
using ISMS_API.Helpers;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace ISMS_API.Services
{
    public class AccountService : IAccountService
    {
        private EmpPortalDbContext _dbContext;
        private IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountService(EmpPortalDbContext dbContext, IMapper mapper, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public AppUserDto AuthenticateUser(UserDto userDto)
        {
            AppUserDto appUserDto = new AppUserDto();
            //var user = _dbContext.Users.SingleOrDefault(u => u.Username == userDto.Username);
            string passwordHash = CryptographyHelper.GenerateHash(userDto.Password);
            User userAccount = _dbContext.Users.Where(u => u.Username == userDto.Username && u.Password == passwordHash).FirstOrDefault();
            if (userAccount != null) 
            {
                PersonUser personUser = _dbContext.PersonUsers.AsNoTracking().Where(u => u.UserId == userAccount.UserId)
                    .Include(u => u.User.Role).Include(u => u.Person).FirstOrDefault();

                appUserDto.PersonID = personUser.PersonId;
                appUserDto.PictureLink = personUser.Person.PictureLink;
                appUserDto.Name = personUser.Person.FirstName + " " + personUser.Person.LastName;
                appUserDto.Role = personUser.User.Role.RoleName;
                appUserDto.Token = _tokenService.CreateToken(userDto);
                
            }
            return appUserDto;
        }

        public async Task<bool> IsUsernameExist(string username)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username == username.ToLower());
        }

        public async Task<int> Register(RegisterUserDto userDto)
        {
            using var hmac = new HMACSHA512();
            var user = new RegisterUserDto
            {
                Username = userDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
                PasswordSalt = hmac.Key,
                RoleId = userDto.RoleId,              
            };
            var userToCreate = _mapper.Map<User>(userDto);
            _dbContext.Users.AddAsync(userToCreate);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
