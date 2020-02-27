using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreCookieAuth.Models
{
    public class LogInModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}