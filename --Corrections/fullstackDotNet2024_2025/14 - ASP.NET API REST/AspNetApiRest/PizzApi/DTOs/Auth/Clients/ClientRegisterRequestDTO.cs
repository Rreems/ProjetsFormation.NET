﻿using System.ComponentModel.DataAnnotations;
using PizzApi.Validators;

namespace PizzApi.DTOs.Auth.Clients
{
    public class ClientRegisterRequestDTO
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [PasswordValidator]
        public string? Password { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z].*", ErrorMessage = "FirstName must start with an Uppercase Letter !")]
        public string? FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z\-]*", ErrorMessage = "LastName must be only Uppercase !")]
        public string? LastName { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
