using AI_PROJECT.DAL.Models;
using AI_PROJECT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.BLL
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void RegisterUser(string username, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password cannot be empty.");
            }

            var existingUser = _userRepository.GetUserByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException("Username already exists.");
            }

            var passwordHash = HashPassword(password);
            var user = new User { Username = username, PasswordHash = passwordHash, Role = role };
            _userRepository.AddUser(user);
        }

        public User AuthenticateUser(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hashOfInput = HashPassword(password);
            return storedHash == hashOfInput;
        }

        public User CurrentUser { get; set; }

        public void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public bool IsAdmin()
        {
            return CurrentUser != null && CurrentUser.Role == "Admin";
        }

    }
}
