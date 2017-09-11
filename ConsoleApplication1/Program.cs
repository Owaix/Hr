using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static iMaths operation = null;

        public Program(iMaths maths)
        {
            operation = maths;
        }

        static void Main(string[] args)
        {
            String Val = Program.operation.Sum(3, 3).ToString();
            Console.WriteLine(Val);
            Console.ReadKey();
        }
    }

    public class Maths : iMaths
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    public class MathsUpdate : iMaths
    {
        public int Sum(int a, int b)
        {
            return a + b + b;
        }
    }
}