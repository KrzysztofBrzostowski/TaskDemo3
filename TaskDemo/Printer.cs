using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    public class Printer
    {
        public void MonoPrint(string content)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Printing {content}");
            Thread.Sleep(3000);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Printed");
        }

        public decimal CalculateCost(string content)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Calculating {content}");
            decimal cost = 0.99M*content.Length;
            Thread.Sleep(3000);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Calculated");
            return cost;
        }

        public Task<Decimal> CalculateCostAsync(string content)
        {
           return Task.Run(() => CalculateCost(content));
        }

        public void ColorPrint()
        {

        }
    }
}
