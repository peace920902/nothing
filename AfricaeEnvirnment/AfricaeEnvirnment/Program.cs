using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AfricaeEnvirnment
{
    class Program
    {
        //static
        //主被動
        //封裝 已能以外部帶入建構式 則盡量使用這方法
        public static Random ran = new Random();
        public static AfricaEnvironment africaEnvironment = new AfricaEnvironment();
        private static int day = 1;
        
        private static void TimeRun()
        {
            while (true)
            {
                Thread.Sleep(5000);
                day++;
                africaEnvironment.DayChange();
                Console.WriteLine($"\n第{day}天");
            }
        }


        static void Main(string[] args)
        {
            Thread thread = new Thread(TimeRun);
            thread.Start();
            
            while (true)
            {
                Console.WriteLine("創造什麼1.草2.斑馬3.獅子");
                int.TryParse(Console.ReadLine(), out var type);
                if(0<type&&type<=Enum.GetNames(typeof(CreatureEnum)).Length)
                {
                    // AfricaEnvironment.CreateCreature很奇怪
                    africaEnvironment.CreateCreature((CreatureEnum)type);        
                }
            }
            
        }


    }
}
