using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    class Sample
    {
        public async Task<long> SumOfNaturalNumbers(int n)
        {
            long sum = 0;
            await Task.Run(()=> { 
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            });
            return sum;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Sample sample = new Sample();
            long s = await sample.SumOfNaturalNumbers(5);
            Console.WriteLine("Continued...");
            Console.WriteLine($"Sum is {s}");
            Console.ReadKey();
        }
    }
}
