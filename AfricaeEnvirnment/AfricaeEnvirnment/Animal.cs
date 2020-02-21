using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AfricaeEnvirnment
{
    public class Animal : Creature
    {
        protected static int Dung { get; set; }

        protected int x_moving = 0 ;
        protected int y_moving = 0 ;
        protected int hunterrange = 0;

        protected virtual void Stool(Action<int> action) {
            Dung++;
            Console.WriteLine(this.Name + "大便了");
            int numberofweed = Dung / 5;
            Dung %= 5;
            if (numberofweed != 0)
            {
                action(numberofweed);
            }
        }

        bool EnableEat()
        {
            switch (CreatureLevel)
            {
                case Level.Herbivore://草食動物
                    if (_iEnvironment.GetAfricaCreatures().Where(o => this.CreatureLevel > o.CreatureLevel)
                        .FirstOrDefault(e =>
                            Math.Abs(this.Point.X_Axis - e.Point.X_Axis) < hunterrange &&
                            Math.Abs(this.Point.Y_Axis - e.Point.Y_Axis) < hunterrange) is Weed)
                        return true;
                    break;
                case Level.Carnivore://肉食動物
                    if (_iEnvironment.GetAfricaCreatures().Where(o => this.CreatureLevel >= o.CreatureLevel && this.CreatureType != o.CreatureType)
                        .FirstOrDefault(e =>
                            Math.Abs(this.Point.X_Axis - e.Point.X_Axis) < hunterrange &&
                            Math.Abs(this.Point.Y_Axis - e.Point.Y_Axis) < hunterrange) is Zebra) 
                        return true;
                    break;
                //case Level.Omnivore:
                //    return true;
                default:
                    return false;
            }
            return false;
        }


        protected virtual void Eat()
        {
        }
        //移動
        protected virtual void Walk()
        {
            this.Point.X_Axis += x_moving;
            this.Point.Y_Axis += y_moving;
            Console.WriteLine($"{this.Name}移動到{Point}");
        }
        //日子改變
        public override void DayChanged()
        {
            this.Walk();
            this.Eat();
            this.Stool(_iEnvironment.WeedCreate);
            base.DayChanged();
        }
    }
}
