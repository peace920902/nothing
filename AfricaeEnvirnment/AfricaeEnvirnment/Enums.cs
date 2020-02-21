using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricaeEnvirnment
{
    public enum  CreatureEnum
    {
        Weed = 1,
        Zebra,
        Lion
    }

    public enum Level
    {
        Plant, //植物
        Herbivore,//草食性動物
        Carnivore,//肉食性動物
        Omnivore //雜食性動物
    }

    public enum Weather
    {
        Sun = 1,
        Rain,
        Windy
    }
}
