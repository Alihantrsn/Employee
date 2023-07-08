using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public delegate bool promotionDelegate(Worker worker);
    public class Worker
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int salary { get; set; }
        public int experience { get; set; }
        public string city { get; set; }


        public static void Promotion(List<Worker>workers,promotionDelegate promotionDelegate)
        {
            foreach (var item in workers)
            {
                if (promotionDelegate(item))
                {
                    Console.WriteLine(item.firstName+ " "+item.lastName);
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker worker1 = new Worker { firstName = "Alihan", lastName = "*****", salary = 3000, experience = 5, city = "Istanbul" };
            Worker worker2 = new Worker { firstName = "Semih", lastName = "*****", salary = 4000, experience = 2, city = "Mersin" };
            Worker worker3 = new Worker { firstName = "Demir", lastName = "*****", salary = 2000, experience = 3, city = "Istanbul" };
            Worker worker4 = new Worker { firstName = "Ali", lastName = "*****", salary = 5000, experience = 4, city = "London" };
            Worker worker5 = new Worker { firstName = "Zehra", lastName = "*****", salary = 1000, experience = 5, city = "Ankara" };
            
            List<Worker> workers = new List<Worker>();
            workers.Add(worker1);
            workers.Add(worker2);
            workers.Add(worker3);
            workers.Add(worker4);
            workers.Add(worker5);
            Worker.Promotion(workers, new promotionDelegate(City_and_Experiance));
            Worker.Promotion(workers, i => i.salary > 3000);


        }
        public static bool City_and_Experiance(Worker w)
        {
            if (w.city=="Istanbul"&&w.experience>=3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
