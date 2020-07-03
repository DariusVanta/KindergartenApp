using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Characterization { get; set; }
        public double Age { get; set; }
        public long Height { get; set; }
        public long Weight { get; set; }
        public ChildrenGroup ChildrenGroup { get; set; }
    }
}
