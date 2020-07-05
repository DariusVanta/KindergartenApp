using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenApp.Models
{
    public class UserKindergarten
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long KindergardenId { get; set; }
        public Kindergarten Kindergarten { get; set; }
    }
}
