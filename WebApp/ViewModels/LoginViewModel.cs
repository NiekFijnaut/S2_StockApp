﻿using Microsoft.Build.Framework;
using System.ComponentModel;

namespace WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        
        public string PasswordHash { get; set; }

        public LoginViewModel(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }

        public LoginViewModel()
        {
                
        }
    }
}
