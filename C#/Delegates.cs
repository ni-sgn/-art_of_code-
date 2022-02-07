using System;
using System.Diagnostics;

namespace Learning
{
    public sealed class Delegates
    {
        //This is like a contract
       public delegate long MyDelegate(Stopwatch sw); 
       
       private long Count_Ticks_During_Function_Call(Stopwatch sw) 
       {
           sw ??= new Stopwatch();
           sw.Start();
           for(int i = 0; i < 100; i++){}
           sw.Stop();

           return sw?.ElapsedTicks ?? 0;
       }

       private long Count_More_Ticks_During_Function_Call(Stopwatch sw)
       {
           Stopwatch New_Stopwatch;
           try{
                New_Stopwatch = sw;
           }catch(NullReferenceException)
           {
              New_Stopwatch = new Stopwatch(); 
           }
           New_Stopwatch.Start();
           for(int i = 0; i < 10000; i++){}
           sw.Stop();

           return sw?.ElapsedTicks ?? 0;
       } 

       private void Every_Action_Has_A_Reaction(Stopwatch sw)
       {
           try
           {
               sw.Start();
           }catch(NullReferenceException ex)
           {
               Console.WriteLine(ex.Message + "\n\n");
               sw = new Stopwatch();
               sw.Start();
           }finally
           {
               sw.Stop();
               Console.WriteLine(sw.Elapsed);
           }

       }

        public void Integration()
        {
            MyDelegate del1 = new MyDelegate(Count_Ticks_During_Function_Call);
            MyDelegate del2 = new MyDelegate(Count_More_Ticks_During_Function_Call);
            Console.WriteLine(del1(new Stopwatch()) + "\n\n" + del2(new Stopwatch()));

            //func is basically a generic delegate, so coder doesn't have to define delegates
            //public delegate TResult Func<in T, out TResult>(T arg);
            Func<Stopwatch, long> func = new Func<Stopwatch, long>(Count_More_Ticks_During_Function_Call);

            //commands(functions that return nothing) have their specific delagets(actions)
            //I guess it's definition should look like this
            //public delegate void Action<in T>(T arg);
            Action<Stopwatch> action = new Action<Stopwatch>(Every_Action_Has_A_Reaction);
            action?.Invoke(null);
        }

    }

} 