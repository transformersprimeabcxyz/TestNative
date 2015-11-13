using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.PlatformAbstractions;

namespace consoleproject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.WriteLine("Life, Universe and Everything: " + NativeMethods.get_number());
            Console.WriteLine("libuv version: " + Marshal.PtrToStringAnsi(LibuvMethods.uv_version_string()));
            Console.WriteLine("SQLite version: " + Marshal.PtrToStringAnsi(SQLiteMethods.sqlite3_libversion()));
            Console.WriteLine("Getting non-existent function: " + NonExistentMethods.sqlite3_get_number());
            Console.WriteLine("Getting non-existent function: " + NonExistentMethods.get_number());
        }
    }

    public static class SQLiteMethods
    {
        [DllImport("sqlite3")]
        public static extern IntPtr sqlite3_libversion();
    }

    public static class LibuvMethods
    {
        [DllImport("libuv")]
        public static extern IntPtr uv_version_string();
    }

    public static class NativeMethods
    {
        [DllImport("nativelib")]
        public static extern int get_number();
    }

    public static class NonExistentMethods
    {
        [DllImport("nonexistent")]
        public static extern int get_number();
        [DllImport("sqlite3")]
        public static extern int sqlite3_get_number();

    }
}
