using System;
using System.Diagnostics;

namespace Learning 
{
    public sealed class ErrorHandling
    {
       public void Check_Null_Value_With_Null_Conditional_Operator(Stopwatch sw)
       {
            sw?.Start();
            Console.WriteLine("If sw isn't null, then call Start() on it");

            /*
            if(sw != null)
                sw.Start()
            */
       } 

        public void Check_Null_Value_With_Null_Coalescing_Operator(Stopwatch sw)
        {
            var New_Stopwatch = sw ?? new Stopwatch();
            Console.WriteLine("If sw is not null then New_Stopwatch is sw, else create new Stopwatch instance");

            /*
            if(sw != null)
            {
                New_Stopwatch = sw;
            }else
            {
                New_Stopwatch = new Stopwatch();
            }
            */
        }

        public void Check_Null_Value_With_Null_Coalescing_Assignment_Operator(Stopwatch sw)
        {
            sw ??= new Stopwatch();
            Console.WriteLine("If sw is null, assign new Stopwatch() to sw");

            /*
            if(sw == null)
            {
                sw = new Stopwatch();
            }
            */


        }


        public void Throwing_Exception(Stopwatch sw)
        {
            //I don't like this implementation
           sw?.Start();
           Exception status = sw == null ? new NullReferenceException() : null;
           throw status;

           //throws are very side-effecty
        }

        public void Catching_Exception()
        {
            try
            {
                Throwing_Exception(null);
            }catch(NullReferenceException e)
            {
                Console.WriteLine("\nType:\n" + e.GetType() + "\nMessage:\n" + e.Message + "\nStackTrace:\n" + e.StackTrace + "\nTargetSite:\n" + e.TargetSite);
            }
           
        }


    }

}