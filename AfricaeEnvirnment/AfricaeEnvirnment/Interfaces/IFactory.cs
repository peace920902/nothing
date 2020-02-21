using System;

namespace AfricaeEnvirnment
{
    public interface IFactory
    {
        Creature CreateCreature(CreatureEnum type);
    }
}