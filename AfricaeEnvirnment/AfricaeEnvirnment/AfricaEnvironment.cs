using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfricaeEnvirnment
{
    class AfricaEnvironment:IEnvironment
    {
        private static List<Creature> _africaCreatures = new List<Creature>();//非洲生物們
        private static IFactory _factory;//生物工廠
        private Weather _africaWeather = Weather.Sun;

        public AfricaEnvironment()
        {
            _factory = new CreateFactory();
        }

        public List<Creature> GetAfricaCreatures()
        {
            return _africaCreatures;
        }

        public void DayChange()//日期改變
        {
            if (IsWeatherChanged())
            {
                WeatherChange();
            }
            foreach (var africaCreature in _africaCreatures.ToArray())
            {
                if (africaCreature.Life != 0)
                {
                    africaCreature.DayChanged();
                }
            }
        }

        private bool IsWeatherChanged()
        {
            int ran = Program.ran.Next(0, 9);
            Weather weather;
            if (ran < 7)
            {
                weather = Weather.Sun;
            }
            else if (ran < 9)
            {
                weather = Weather.Windy;
            }
            else
                weather = Weather.Rain;
            if (weather != this._africaWeather)
            {
                return true;
            }
            return false;
        }

        public void WeatherChange()
        {
            
        }

        public void Creature_DeadEvent(Creature creature) //生物死亡
        {
            _africaCreatures.Remove(creature);
        }

        public void WeedCreate(int dung)//生物大便觸發的事件
        {
            while (dung > 0)
            {
                CreateCreature(CreatureEnum.Weed);
                dung--;
            }
        }

        public Creature CreateCreature(CreatureEnum type)//製造生物
        {
            var creature = _factory.CreateCreature(type);
            _africaCreatures.Add(creature);
            return creature;
        }

    }
}
