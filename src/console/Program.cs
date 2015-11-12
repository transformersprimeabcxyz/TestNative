using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.PlatformAbstractions;

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
        [DllImport("sqlite3")]
        public static extern int sqlite3_libversion_number();
    }
}
