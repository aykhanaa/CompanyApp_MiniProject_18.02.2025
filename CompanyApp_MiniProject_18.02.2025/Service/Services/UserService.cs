using Domain.Entities;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService()
        {
            _userRepo =  new UserRepository();
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepo.GetAllAsync();
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var datas = await _userRepo.GetAllAsync();
            return datas.Any(m => m.Email.ToLower() == email.ToLower() && m.Password.ToLower() == password.ToLower());
        }

        public async Task RegisterAsync(User user)
        {
            await _userRepo.CreateAsync(user);
        }
    }
}
