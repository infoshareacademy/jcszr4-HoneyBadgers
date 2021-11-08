﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using HoneyBadgers.Logic.Helpers;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Repositories
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
            user.LastName = StringValidation(2, 30);

            Console.WriteLine("\nEnter email:");
            var email = Console.ReadLine();
            user.Email = EmailValidation(email);

            user.Id = GenerateId();
            user.MoviesWatched = new List<Movie>();

            return user;
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

                email = Console.ReadLine();

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
        public void PrintUsers()
        {
            Console.WriteLine("LIST OF USERS:");
            foreach (var user in Users)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"ID: {user.Id} || FIRSTNAME: {user.FirstName} || LASTNAME: {user.LastName} || EMAIL: {user.Email}");
                Console.ResetColor();
            }
        }
        private void EditUserData()
        {
            Console.WriteLine("Enter Email of the user you wish to edit");
            var input = Console.ReadLine();
            var selectedUser = Users.FirstOrDefault(usr => usr.Email.Equals(input, StringComparison.OrdinalIgnoreCase));

            if (selectedUser == null) return;


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
        }

        public void UserDataEdition()
        {
            Console.WriteLine("Would you like to edit any user data?");
            Console.WriteLine("Press ENTER to print the list of users or any key to continue without...");

            ConsoleKey choice = Console.ReadKey(true).Key;
            if (choice == ConsoleKey.Enter) { PrintUsers(); }
            EditUserData();
            Console.WriteLine("Changes saved successfully");
        }
    }
}
