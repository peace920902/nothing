using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricaeEnvirnment
{
    class CreateFactory:IFactory
    {
        public Creature CreateCreature(CreatureEnum creaturetype) {
            Creature creature = null;
            switch (creaturetype)
            {
                case CreatureEnum.Weed: //weed
                    creature = new Weed();
                    break;
                //zebra
                case CreatureEnum.Zebra: //zebra
                    creature = new Zebra();
                    break;
                //lion
                case CreatureEnum.Lion: //lion
                    creature = new Lion();
                    break;
            }
            return creature;
        }
    }
}
