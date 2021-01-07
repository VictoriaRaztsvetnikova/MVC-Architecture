using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Books.ViewModels
{
    public partial class Register
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20,ErrorMessage = "This field is required(at least 3 to 20 characters)!"), MinLength(3)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)] 
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9].*[0-9])(?=.*[_*&$]).*$", ErrorMessage = "Password must contain at least one lowercase or uppercase Latin letter, at least 1 special character (_ * & $) and at least 2 digits!")]
        public string Password { get; set; }
      
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "This field is required and must match the password!")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}