using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_El_Baratico.Models
{
    public class Administrator
    {
        private string name;
        private string lastname;
        private string username;
        private string address;
        private string password;
        private string email;
        private string confirm;


        [Required(ErrorMessage = "Please Enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter lastname")]
        public string Lastname { get { return lastname; } set { lastname = value; } }
        [Required(ErrorMessage = "Please Enter username")]
        public string Username { get { return username; } set { username = value; } }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get { return address; } set { address = value; } }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get { return email; } set { email = value; } }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string Confirm
        {
            get { return confirm; }
            set { confirm = value; }
        }
    }
}