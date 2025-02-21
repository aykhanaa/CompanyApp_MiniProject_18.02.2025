using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CompanyApp_MiniProject_18._02._2025.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        public async Task GetAllAsync()
        {
              var allUser = await _userService.GetAllAsync();
            foreach (var item in allUser)
            {
                Console.WriteLine($"Id:{item.Id},Fullname:{item.FullName},Email:{item.Email},Password:{item.Password}");
            }
        }

        public async Task RegisterAsync()
        {
            try
            {
                var allUser = await _userService.GetAllAsync();

            UserFullName: Console.WriteLine("Add user Fullname:");
                string userFullName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(userFullName))
                {
                    goto UserFullName;
                }

            UserEmail: Console.WriteLine("Add user Email");
                string userEmail = Console.ReadLine();

                if (string.IsNullOrEmpty(userEmail))
                {
                    goto UserEmail;
                }

            UserPassword: Console.WriteLine("Add user password");
                string userPassword = Console.ReadLine();

                if (string.IsNullOrEmpty(userPassword))
                {
                    goto UserPassword;
                }

                await _userService.RegisterAsync(new User { FullName = userFullName, Email = userEmail, Password = userPassword });
                Console.WriteLine(ResponseMessages.CreateSuccess);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            



        }



    }
}
