using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.WriteLine("SQLite version number: " + SQLiteMethods.sqlite3_libversion_number());

        }
    }

    public static class SQLiteMethods
    {
        [DllImport("libuv")]
        public static extern int sqlite3_libversion_number();
    }
}
