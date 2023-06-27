using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)//варіант 22
        {
            double alpha = 23;
            double x = Convert.ToDouble(args[0]);
            double n = Math.Sin(alpha + x) * Math.Sin(alpha + x) / (0.5 + Math.Exp(-alpha * x)) *
                Math.Sqrt((Math.Log(alpha + 2) - Math.Log10(x - 2)) / (Math.Atan(Math.Sin(x) * Math.Sin(x) + Math.Pow(Math.Tan(alpha), 3))));
            args[0] = n + "";
        }
    }
}
