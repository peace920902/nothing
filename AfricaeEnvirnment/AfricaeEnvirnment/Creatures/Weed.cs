using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricaeEnvirnment
{
    class Weed:Creature
    {
        private static int no;
        public Weed() { 
            no++;
            CreatureType = CreatureEnum.Weed;
            CreatureLevel = Level.Plant;
            Name = "Weed"+no;
            Life = 5;
            Point = CreatePosition();
        }
    }
}
