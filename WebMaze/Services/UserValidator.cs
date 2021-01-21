using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;

namespace WebMaze.Services
{
    public class UserValidator
    {
        private CitizenUserRepository citizenUserRepository;
        private readonly int requiredPasswordLength;
        private string validationMessages = string.Empty;

        public UserValidator(CitizenUserRepository citizenUserRepository, int requiredPasswordLength = 3)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.requiredPasswordLength = requiredPasswordLength;
        }

        public List<string> Validate(CitizenUser user)
        {
            var errors = new List<string>();
            if (user == null)
            {
                errors.Add("Specified user does not exist.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(user.Login))
            {
                errors.Add($"Login '{user.Login}' is invalid, can only contain letters or digits.");
            }

            var owner = citizenUserRepository.GetUserByName(user.Login);

            if (owner != null && owner.Id != user.Id)
            {
                errors.Add($"Login {user.Login} is already taken.");
            }

            ValidatePassword(user.Password);

            return errors;
        }

        public void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ValidationException("Enter the password.");
            }

            if (password.Length < requiredPasswordLength)
            {
                var passwordTooShort = $"Passwords must be at least {requiredPasswordLength} characters.";
                validationMessages += Environment.NewLine + passwordTooShort;
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                var passwordTooShort = $"Passwords must have at least one digit ('0'-'9').";
                validationMessages += Environment.NewLine + passwordTooShort;
            }
        }
    }
}
