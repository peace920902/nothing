using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricaeEnvirnment
{
    public class Zebra:Animal
    {
        private static int no;
        public Zebra()
        {
            CreatureLevel = Level.Herbivore;
            CreatureType = CreatureEnum.Zebra;
            no++;
            Name = "Zebra"+no;
            Life = 3;
            Point = CreatePosition();
            hunterrange = 5;
        }

        protected override void Walk()
        {
            x_moving = Program.ran.Next(0, 6);
            y_moving = Program.ran.Next(0, 6);
            base.Walk();
        }

        protected override void Eat()
        {
            //找出5碼內的草
            if (_iEnvironment.GetAfricaCreatures().Where(o => o.CreatureType == CreatureEnum.Weed)
                .FirstOrDefault(e =>
                    Math.Abs(this.Point.X_Axis - e.Point.X_Axis) < hunterrange &&
                    Math.Abs(this.Point.Y_Axis - e.Point.Y_Axis) < hunterrange) is Weed weed)
            {
                Life += 3;
                Console.WriteLine($"{this.Name}吃了{weed.Name}");
                weed.Dead(_iEnvironment.Creature_DeadEvent);
                base.Eat();
            }
        }
    }
}
