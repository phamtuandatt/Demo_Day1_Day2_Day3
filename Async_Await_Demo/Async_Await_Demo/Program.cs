using System;
using System.Data;
using System.Reflection;

namespace Async_Await_Demo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task t1 = Task1();
            Task t2 = Task2();
            Task<int> t3 = Task3();

            // Read file 
            Task<string> t4 = DrawCat("D:\\Demo\\Async_Await_Demo\\Async_Await_Demo\\TextFile1.txt");

            await t1;
            await t2;
            await t3;
            var picture_Cat= await t4;

            Console.WriteLine($"------Result of T3: {t3.Result} ");
            Console.WriteLine(picture_Cat);

            Console.Read();
        }

        static async Task Task1()
        {

            Task t1 = new Task(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    //Thread.Sleep(1000);
                    Console.WriteLine("Task 1 excuted");
                }
            });
            t1.Start();
            await t1;
            Console.WriteLine("----------Task 1 complete--------");
        }

        static async Task Task2()
        {

            Task t2 = new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    //Thread.Sleep(1000);
                    Console.WriteLine("Task 2 excuted");
                }
            });
            t2.Start();
            await t2;
            Console.WriteLine("----------Task 2 complete--------");

        }

        static async Task<int> Task3()
        {
            int[] arg = new int[] { 1, 2, 4, 6, 7, 8 };

            Task<int> t = new Task<int>(() =>
            {
                int tong = 0;
                for (int i = 0; i < arg.Length; i++)
                {
                    //Thread.Sleep(1000);
                    tong += arg[i];
                    Console.WriteLine("Task 3 excuting.....");
                }
                return tong;
            });
            t.Start();
            await t;
            Console.WriteLine("----------Task 3 complete--------");

            return t.Result;
        }

        static async Task<string> DrawCat(string url)
        {
            // Read file -> ImageCat
            string cat = await File.ReadAllTextAsync(url);

            return cat;
        }
    }
}