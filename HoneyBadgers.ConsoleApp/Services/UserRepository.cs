using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp.Services
{
    public class UserRepository : IUserRepository
    {
        public List<User> Users { get; private set; } = new List<User>();

        public UserRepository()
        {
            try
            {
                Users.AddRange(FileDataReader.LoadUsers());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddUser()
        {
            Console.WriteLine("Adding new user\n\n");
            var user = GetUserData();
            Users.Add(user);
            Console.WriteLine("The user has been added correctly");
        }

        public User GetUserData()
        {

            var user = new User();
            Console.WriteLine("\nEnter director");
            user.FirstName = Console.ReadLine() ?? "";

            Console.WriteLine("\nEnter writer:");
            user.LastName = Console.ReadLine() ?? "";

            Console.WriteLine("\nEnter actors:");
            user.Email = EmailValidation();

            user.Id = GenerateId();
            user.Movies = new List<Movie>();

            return user;
        }

        private string EmailValidation()
        {
            var email = "";
            while (true)
            {
                var valid = MailAddress.TryCreate(Console.ReadLine(), out var input);
                if (!valid)
                {
                    Console.WriteLine("The given value is incorrect. The value provided should be of the form name@something.domain. Try again:");
                }
                else
                {
                    if (Users.Any(u => u.Email == input.ToString()))
                    {
                        Console.WriteLine("There is already a user with the given email");
                    }
                    else
                    {
                        email = input.ToString();
                        break;
                    }
                }
            }
            return email;
        }

        private string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
