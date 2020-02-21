using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricaeEnvirnment
{
    public class Creature
    {
        protected IEnvironment _iEnvironment;
        public CreatureEnum CreatureType { get; set; }
        public Level CreatureLevel { get; set; }
        public string Name { get; set; }
        public int Life { get; set; }
        public Position Point { get; set; }

        public Creature()
        {
            _iEnvironment = Program.africaEnvironment;
        } 

        public virtual void Dead(Action<Creature> action)
        {
            Console.WriteLine($"{this.Name}死了");
            action(this);
        }

        public virtual void DayChanged()
        {
            this.Life--;
            if (this.Life == 0)
            {
                this.Dead(_iEnvironment.Creature_DeadEvent);
            }
        }

        protected Position CreatePosition()
        {
            Position position = new Position {X_Axis = Program.ran.Next(0, 50), Y_Axis = Program.ran.Next(0, 50)};
            Console.WriteLine($"{this.Name}在{position}出生了");
            return position;
        }
    }
}
