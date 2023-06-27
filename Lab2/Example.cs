using System;
using System.Data;
using System.Linq;
using System.Xml.Schema;

namespace Lab2
{
    public class Example
    {
        private int _field;
        public Example(int field)
        {
            _field = field;
            Console.WriteLine("Ctor is called");
            Max(1, 2);//2
            Max(1, 2, 4);//4
            Max(5, 1, 9, 5);//9
        }

        public int Max(params int[] arr) {
            return arr.Max();
        }

    }
}
