using System;

namespace KindergartenApp.Models
{
    public enum ChildrenGroup
    {
        Small,
        Middle,
        Bigger
    }
    public class Child
    {
        public long ChildId { get; set; }
       // [Required]
        //[MaxLength(10, ErrorMessage = "Name must have almost 10 characters ")]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Characterization { get; set; }
        public double Age { get; set; }
        public long Height { get; set; }
        public double Weight { get; set; }
       public ChildrenGroup ChildrenGroup { get; set; }


        // public Kindergarten KindergartenID { get; set; }
     //   public long KindergartenID { get; set; }
     //   public Kindergarten Kindergarten { get; set; } //navigation property
        // one to many ma multi copii la o singura gradinita
        //in clasa copii sa am KindergardenId
        //in clasa gradinita sa avem un parametru care sa fie o lista /array de copii




    }
}
