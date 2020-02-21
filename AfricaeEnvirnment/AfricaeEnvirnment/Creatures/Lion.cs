using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricaeEnvirnment
{
    public class Lion:Animal
    {
        private static int no;

        public Lion()
        {
            CreatureType = CreatureEnum.Lion;
            CreatureLevel = Level.Carnivore;
            no++;
            Name = "Lion"+no;
            Life = 2;
            Point = CreatePosition();
            hunterrange = 8;
        }

        protected override void Walk()
        {
            x_moving = Program.ran.Next(0, 5);
            y_moving = Program.ran.Next(0, 5);
            base.Walk();
        }

        protected override void Eat()
        {
            //找出狩獵範圍內的斑馬
            if (_iEnvironment.GetAfricaCreatures().Where(o => o.CreatureType == CreatureEnum.Zebra)
                .FirstOrDefault(e =>
                    Math.Abs(this.Point.X_Axis - e.Point.X_Axis) < hunterrange &&
                    Math.Abs(this.Point.Y_Axis - e.Point.Y_Axis) < hunterrange) is Zebra zebra)
            {
                Life += 2;
                Console.WriteLine($"{this.Name}吃了{zebra.Name}");
                zebra.Dead(_iEnvironment.Creature_DeadEvent);
                base.Eat();
            }
        }
        protected override void Stool(Action<int> action)
        {
            Dung+=2;
            base.Stool(action);
        }
    }
}
