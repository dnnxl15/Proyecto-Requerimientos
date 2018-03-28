using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_El_Baratico.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        // Attributes
        private static Client instance;
        private string name;
        private string lastname;
        private string username;
        private string address;
        private string password;
        private string email;
        private string confirm;
        private int id;

        public static Client Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Client();
                }
                return instance;
            }
        }


        // Getter and setter

        [Required(ErrorMessage = "Please Enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter lastname")]
        public string Lastname { get { return lastname; }  set { lastname = value; } }
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
        public string Confirm { get { return confirm; } set{ confirm = value; }}

        public int Id { get; set; }
    }
}