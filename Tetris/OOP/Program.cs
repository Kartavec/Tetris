using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Human[] humans = new Human[2];
            humans[0] = new Employee(12, 100000);
            humans[1] = new Officer(30, "Подполковник");

            //Human h1 = new Human();

            foreach(Human h in humans)
            {
                h.Write();
            }


            Console.ReadLine();
        }
    }
}
