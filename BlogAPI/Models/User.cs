using BlogAPI.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlogAPI.Models
{
    public class User
    {
        /// <summary>
        /// unique identifier of this user.
        /// </summary>
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AuthToken { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PostsCount { get; set; }
        public UserPermission Permission { get; set; }


        public bool IsPasswordCorrect(string userInput)
        {
            var result = GetPasswordHasher().VerifyHashedPassword(this, Password, userInput);
            return result != PasswordVerificationResult.Failed;
        }
        public string GetHashedPassword(string userInput)
        {
            return GetPasswordHasher().HashPassword(this, userInput);
        }
        
        public static PasswordHasher<User> GetPasswordHasher()
        {
            return new PasswordHasher<User>();
        }
    }
}
