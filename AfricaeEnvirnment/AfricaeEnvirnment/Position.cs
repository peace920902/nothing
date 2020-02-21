using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricaeEnvirnment
{
    public class Position
    {
        public int X_Axis { get; set; }
        public int Y_Axis { get; set; }
        public override string ToString()
        {
            return $"({X_Axis},{Y_Axis})";
        }
    }
}
