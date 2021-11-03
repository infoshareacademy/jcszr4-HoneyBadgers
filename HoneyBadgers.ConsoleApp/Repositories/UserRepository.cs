using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Helpers;

namespace HoneyBadgers.ConsoleApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> Users { get; private set; } = new List<User>();

        public UserRepository()
        {
            Users.AddRange(FileDataReader.LoadUsers());
        }

        public void AddUser()
        {
            Console.WriteLine("Adding new user");
            var user = SetNewUser();
            Users.Add(user);
            Console.WriteLine("The user has been added correctly");
        }

        private User SetNewUser()
        {

            var user = new User();
            Console.WriteLine("\nEnter firstname");
            user.FirstName = StringValidation(2, 30);

            Console.WriteLine("\nEnter lastname:");
            user.FirstName = StringValidation(2, 30);

            Console.WriteLine("\nEnter email:");
            user.Email = EmailValidation();

            user.Id = GenerateId();
            user.Movies = new List<Movie>();

            return user;
        }

        private string EmailValidation()
        {
            string email;
            while (true)
            {

                var input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("The given value is incorrect. The value provided should be of the form name@something.domain. Try again:");
                }
                else
                {
                    var valid = MailAddress.TryCreate(input, out var result);
                    if (!valid)
                    {
                        Console.WriteLine("The given value is incorrect. The value provided should be of the form name@something.domain. Try again:");
                    }
                    else
                    {
                        if (Users.Any(u => u.Email == result.ToString()))
                        {
                            Console.WriteLine("There is already a user with the given email");
                        }
                        else
                        {
                            email = result.ToString();
                            break;
                        }
                    }
                }
                
            }
            return email;
        }

        private string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }

        private string StringValidation(int minLength, int maxLength)
        {
            var valid = false;
            string input = "";
            while (!valid)
            {
                input = Console.ReadLine();
                valid = Validators.StringValidator(input, minLength, maxLength) && !(input.Any(char.IsDigit));
                if (!valid)
                {
                    Console.WriteLine("The given value is incorrect. The provided value should be a word from 2 to 30 characters which does not contain numbers.");
                }
            }

            return input;
        }
    }
}
