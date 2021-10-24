using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp.Services
{
    public class UserRepository : IUserRepositor
    {
        public List<User> Users { get; private set; } = new List<User>();

        public UserRepository()
        {
            Users.AddRange(FileDataReader.LoadUsers());
        }

        public void IOnlyExistInConcreteImplementation()
        {

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
            var type = typeof(User);
            var properties = type.GetProperties();
            var user = new User();
            foreach (var property in properties)
            {
                if (property.Name is "Id" or "Movies")
                {
                    continue;
                }
                Console.WriteLine($"Enter {property.Name.ToLower()}");
                if (property.Name == "Email")
                {
                    var email = EmailValidation();
                    property.SetValue(user, email);
                }
                else
                {
                    var input = Console.ReadLine();
                    property.SetValue(user, input ?? "");
                }
            }
            Console.WriteLine();
            user.Id = GenerateId();
            user.Movies = new List<Movie>();

            return user;
        }

        private string EmailValidation()
        {
            var valid = false;
            var email = "";
            while (!valid)
            {
                valid = MailAddress.TryCreate(Console.ReadLine(), out var input);
                if (!valid)
                {
                    Console.WriteLine("The given value is incorrect. The value provided should be of the form name@something.domain. Try again:");
                }
                else
                {
                    email = input.ToString();
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
