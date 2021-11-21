using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.ConsoleApp.Helpers;
using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Repositories;

namespace HoneyBadgers.ConsoleApp.Services
{
    public class UserConsoleService
    {
        private IUserRepository _usersRepository;
        public UserConsoleService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public User AddUser()
        {
            Console.WriteLine("Adding new user");
            var user = new User();
            Console.WriteLine("\nEnter firstname");
            user.FirstName = StringValidation(2, 30);

            Console.WriteLine("\nEnter lastname:");
            user.LastName = StringValidation(2, 30);

            Console.WriteLine("\nEnter email:");
            var email = Console.ReadLine();
            user.Email = EmailValidation(email);

            user.Id = GenerateId();
            user.Movies = new List<Movie>();

            return user;
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
        public void PrintUsers()
        {
            Console.WriteLine("LIST OF USERS:");
            foreach (var user in _usersRepository.Users)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"ID: {user.Id} || FIRSTNAME: {user.FirstName} || LASTNAME: {user.LastName} || EMAIL: {user.Email}");
                Console.ResetColor();
            }
        }
        public User EditUserData()
        {
            Console.WriteLine("Enter Email of the user you wish to edit");
            var input = Console.ReadLine();
            var selectedUser = _usersRepository.Users.FirstOrDefault(usr => usr.Email.Equals(input, StringComparison.OrdinalIgnoreCase));

            if (selectedUser == null) new User();


            Console.WriteLine($"Current user name is: {selectedUser.FirstName}. Type new name or press enter to continue without changes");
            var firstName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(firstName.Trim()))
            {
                selectedUser.FirstName = firstName;
            }

            Console.WriteLine($"Current user last name is: {selectedUser.LastName}. Type new last name or press enter to continue without changes");
            var lastName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(lastName.Trim()))
            {
                selectedUser.LastName = lastName;
            }
            Console.WriteLine($"Current user email is: {selectedUser.Email}. Type new email or press enter to continue without changes");
            var email = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(email.Trim()))
            {
                selectedUser.Email = EmailValidation(email);
            }

            return selectedUser;
        }

        private string EmailValidation(string email)
        {
            while (true)
            {
                if (String.IsNullOrEmpty(email))
                {
                    Console.WriteLine("The given value is incorrect. The value provided should be of the form name@something.domain. Try again:");
                }
                else
                {
                    var valid = MailAddress.TryCreate(email, out var result);
                    if (!valid)
                    {
                        Console.WriteLine("The given value is incorrect. The value provided should be of the form name@something.domain. Try again:");
                    }
                    else
                    {
                        if (_usersRepository.Users.Any(u => u.Email == result.ToString()))
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

                email = Console.ReadLine();

            }
            return email;
        }

        private string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
