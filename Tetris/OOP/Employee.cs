using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Employee : Human
    {
        public int salary;   // Зарплата
        public Employee(int a, int s)
        {
            age = a;        // ВСЁ ОК !!!
            salary = s;
        }

        public Employee() { }

        public override void Write()
        {
            Console.WriteLine($"age: {age}. height: {height}. salary: {salary}");
        }

    }
}



