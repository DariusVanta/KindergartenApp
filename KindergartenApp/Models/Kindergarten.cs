using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenApp.Models
{
    public class Kindergarten
    {
        public long KindergartenId { get; set; }
        // [Required]
        //[MaxLength(12, ErrorMessage = "Name must have almost 12 characters ")]
        public string KindergartenName { get; set; }
        public string Address { get; set; }
        public long Capacity { get; set; }

       // public ICollection<Child> Children { get; set; } // 4 one to many  o gradinita cu mai multi copii

        //4 M2M 
     //   public IList<UserKindergarten> UserKindergartens { get; set; } = new List<UserKindergarten>();
    }
}