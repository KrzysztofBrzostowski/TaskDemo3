using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Hello World!");
            Printer printer = new Printer();
            
            Task task = new Task(() => printer.MonoPrint("Witaj01"));

            //Task<decimal> task2 = new Task<decimal>(() => printer.CalculateCost("przykladowy koszt"));
            //task2.ContinueWith(t => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Koszt: {t.Result}"));
            //task2.Start();

            //Task<decimal> task2 = printer.CalculateCostAsync("przykladowy koszt");
            //task2.ContinueWith(t => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Koszt: {t.Result}"));

            //await "wyciaga" wynik taska, dzieki temu typy pasuja do siebie
            decimal cost = await printer.CalculateCostAsync("przykladowy koszt");
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Koszt: {cost}");


            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Press enter to exit");
            Console.ReadLine();
            //printer.MonoPrint("Witaj01");
        }
    }
}
