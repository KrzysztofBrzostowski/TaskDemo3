using System;
using System.Data.SqlClient;
using System.IO;

namespace IDisposableDemo
{
    public class Printer : IDisposable
    {
        public void Print(string content)
        {
            if (content.Length > 10)
            {
                throw new Exception("Za dlugi tekst");
            }
            Console.WriteLine(content);
            File.AppendAllText("printer.txt", content);
        }

        public void Clean()
        {
            File.Delete("printer.txt");
        }

        public void Dispose()
        {
            File.Delete("printer.txt");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //using (Customer c = new Customer()) { }
            //TryCatchTest();

            using (SqlConnection connection = new SqlConnection())
            using (SqlCommand command = new SqlCommand("", connection))
            {
            }

            try
            {
                using (Printer printer = new Printer())
                {
                    printer.Print("Hello");
                    printer.Print("World");
                    printer.Print("Przykladowy tekst");

                    //printer.Dispose();
                }
            }
            catch
            {
                Console.WriteLine("Obsluzono wyjatek");
            }
            Console.WriteLine("Hello World!");

        }

        private static void TryCatchTest()
        {
            Printer printer = new Printer();
            try
            {
                printer.Print("Hello");
                printer.Print("World");
                //printer.Print("Przykladowy tekst");
                //printer.Dispose();
            }
            catch
            {
                Console.WriteLine("Wystapil blad podczas drukowania");
            }
            //finally
            //{
            //    printer.Clean();
            //}
        }
    }
}
