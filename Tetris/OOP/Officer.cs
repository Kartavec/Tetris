using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Officer : Human
    {
        public string rank;     // Звание

        public Officer(int a, string r)
        {
            age = a;
            rank = r;
        }
        public override void Write()
        {
            Console.WriteLine($"age: {age}. height: {height}. rank: {rank}");
        }

    }
}



