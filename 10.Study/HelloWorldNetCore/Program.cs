using Jst.UtilStandard.UtilsHelper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorldNetCore
{
    class Program
    {
        static void Main(string[] args)
        {

            //C1 c = new C1();
            //bool flag = c is C1;
            //Console.WriteLine("Hello World!");
            //Console.ReadKey();

            Task.Factory.StartNew(() => {
                for (int i = 0; i < 100; i++)
                {
                    long id= IdHelper.NextId();
                    Console.WriteLine($"Current Thread Id {Thread.CurrentThread.ManagedThreadId} get id = {id}");
                   // Thread.Sleep(10);
                }
            });

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    long id = IdHelper.NextId();
                    Console.WriteLine($"Current Thread Id {Thread.CurrentThread.ManagedThreadId} get id = {id}");
                   // Thread.Sleep(10);
                }
            });
            Console.ReadKey();
        }


        class C1
        {
            string name;
            int age;
        }
    }
}