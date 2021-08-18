using System;
using System.Data.SqlClient;
using System.IO;

namespace IDisposableDemo
{
    public class LaserPrinter : IDisposable
    {
        public LaserPrinter()
        {

        }

        ~LaserPrinter()
        {
            Console.WriteLine("Destruktor");
        }

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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            //tu zwalniamy zarzadzalne
            if (disposing)
            {

            }

            //tu zwalniamy niezarzadzalne
            //np. zamykamy połączenie do bazy danych; obiekt DbConnection metoda Close
            //odładowujemy bibliotekę z pamięci
            File.Delete("printer.txt");

            _disposed = true;
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
                using (LaserPrinter printer = new LaserPrinter())
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
            LaserPrinter printer = new LaserPrinter();
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
