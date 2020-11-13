using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaDay.Models
{
    public class User
    {

        public int Id;
        static int nextId = 1;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; }

        public User()
        {
            Id = nextId;
            nextId++;
        }

        public User(string username, string email, string password) : this()
        {
            Username = username;
            Email = email;
            Password = password;
        }
    }
}
