
using System.Collections.Generic;

namespace AfricaeEnvirnment
{
    public interface IEnvironment
    { 
        Creature CreateCreature(CreatureEnum type);
        void Creature_DeadEvent(Creature creature);
        List<Creature> GetAfricaCreatures();

        void WeedCreate(int dung);
        void WeatherChange();
        
    }
}
