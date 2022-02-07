using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace Learning
{
    public sealed class Asynchronous
    {
        private async Task<long> Calculate_Big_Sum()
        {
            Stopwatch sw = new Stopwatch();

            int sum = 0;
            sw?.Start();
            for(int i = 0; i < 900000; i++ )
            {
                sum+=i;
            }
            sw.Stop();
            Console.WriteLine($"Asynchronous Function Took: {sw.Elapsed} time\n");
            return sum;
        }

        public async Task Integration()
        {
            //here asynchronous work already starts
            Task<long> Computing_Work = Calculate_Big_Sum();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for(int i = 0; i < 20; i++)
               Console.WriteLine("Giving Time To Asynchronous Job to Finish");
            sw.Stop();

    
            Console.WriteLine($"We gave {sw.Elapsed} time");
            sw.Reset();
            sw.Start();
            //await unwraps the task on it's own when it's finished, yields execution here and gives control to caller
            //because unwrapping the Future itself takes the time, this awaiting also takes some time even if asynchronous 
            //task finishes really fast
            long result = await Computing_Work;
            sw.Stop();
            Console.WriteLine($"We waited for: {sw.Elapsed} time ");

            sw.Reset();
            sw.Start();
            Console.WriteLine($"Printing itself takes: {sw.Elapsed} time");
            sw.Stop();
           
            Console.WriteLine($"Result is: {result}");
        }
    }
}