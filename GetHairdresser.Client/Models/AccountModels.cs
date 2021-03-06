﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace GetHairdresser.Client.Models
{
   
    public class UserProfile
    {
        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Sure name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Required(ErrorMessage="Enter your age please")]
        [Range(8,80,ErrorMessage="Enter your real age")]
        [Display(Name = "Age")]
        public int age { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string location { get; set; }

        [ScaffoldColumn(false)]
        public string email { get; set; }

        [ScaffoldColumn(false)]
        public string UserFacebook { get; set; }

        [ScaffoldColumn(false)]
        public string typeClient { get; set; }
        
        [ScaffoldColumn(false)]
        public Guid UserGuid { get; set; }
        
        [ScaffoldColumn(false)]
        public virtual List<JobAppointment> JobAppointments { get; set; }

        [ScaffoldColumn(false)]
        public string ExternalLoginData { get; set; }

    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
