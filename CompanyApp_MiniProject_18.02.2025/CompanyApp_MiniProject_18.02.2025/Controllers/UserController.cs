using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CompanyApp_MiniProject_18._02._2025.Controllers
{
    public class UserController
    {
        

        private readonly IUserService _userService;
        public bool IsLoggedIn { get; set; }
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

                if (string.IsNullOrWhiteSpace(userFullName))
                {
                    Console.WriteLine(ResponseMessages.InputRequired);
                    goto UserFullName;
                }
                if (!userFullName.CheckFullNameFormat())
                {
                    Console.WriteLine(ResponseMessages.InvalidFullNameFormat);
                    goto UserFullName;
                }

            UserEmail: Console.WriteLine("Add user Email");
                string userEmail = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userEmail))
                {
                    goto UserEmail;
                }
                if (!userEmail.CheckEmailFormat())
                {
                    Console.WriteLine(ResponseMessages.InvalidEmailFormat);
                    goto UserEmail;
                }
                if (allUser.Any(m => m.Email.ToLower() == userEmail.ToLower()))
                {
                    Console.WriteLine("User name already exists");
                    goto UserEmail;
                }

            UserPassword: Console.WriteLine("Add user password");
                string userPassword = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userPassword))
                {
                    Console.WriteLine(ResponseMessages.InputRequired);
                    goto UserPassword;
                }
                if (!userPassword.CheckPasswordFormat())
                {
                    Console.WriteLine(ResponseMessages.IncorrectFormat);
                    goto UserPassword;
                }
                if (!Regex.IsMatch(userPassword, "[a-z]") || !Regex.IsMatch(userPassword, "[A-Z]"))
                {
                    Console.WriteLine("Password must contain at least one uppercase and one lowercase letter");
                    goto UserPassword;
                }

                ConfPassword: Console.WriteLine("Add confirm password");
                string  confirmPassword = Console.ReadLine();

                if(confirmPassword != userPassword)
                {
                    Console.WriteLine(ResponseMessages.InvalidPasswordFormat);
                    goto ConfPassword;
                }


                await _userService.RegisterAsync(new User { FullName = userFullName, Email = userEmail, Password = userPassword });
                Console.WriteLine(ResponseMessages.CreateSuccess);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            



        }

        public async Task LoginAsync()
        {
            Email: Console.WriteLine("Enter email");
            string email = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine(ResponseMessages.InputRequired);
                goto Email;
            }
            if (!email.CheckEmailFormat())
            {
                Console.WriteLine(ResponseMessages.InvalidEmailFormat);
                goto Email;
            }



        Password: Console.WriteLine("Enter password");
            string password = Console.ReadLine().Trim();
            
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine(ResponseMessages.InputRequired);
                goto Password;
            }
            if (!password.CheckPasswordFormat())
            {
                Console.WriteLine(ResponseMessages.IncorrectFormat);
                goto Password;
            }
            try
            {
                var checkLogin = await _userService.LoginAsync(email, password);
                if (checkLogin)
                {
                    IsLoggedIn = true;
                    Console.WriteLine(ResponseMessages.LoginSuccess);
                }
                else
                {
                    Console.WriteLine(ResponseMessages.LoginFailed);
                    goto Email;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
 
        }



    }
}
