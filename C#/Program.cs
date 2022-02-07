using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace Learning 
{
    class Program
    {
        static void Main(string[] args)
        {

                 Asynchronous asynch = new();
                 Task taskHolder = asynch.Integration(); 
                 for(int i = 0; i < 20; i++)
                 {
                     Console.WriteLine("This code runs parallel to the asynchronous calculation Task");
                 }
                 taskHolder.Wait();
        }
    }
}
