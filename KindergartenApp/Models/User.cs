using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       // public IList<UserKindergarten> UserKindergatens { get; set; } // = new List<UserKindergarten>();
        //where one Teacher/User can enroll for many Kindergatens and, in the same way, one Kindergaten can be joined by many Teachers/Users .
    }
}
