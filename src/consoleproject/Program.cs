using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.PlatformAbstractions;

namespace consoleproject
{
    public class Program
    {
        private static readonly bool _isMonoDarwin = isMonoDarwin();

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world" + (_isMonoDarwin ? " from Mono on Darwin" : string.Empty));
            Console.WriteLine("Life, Universe and Everything: " + get_number());
            Console.WriteLine("libuv version: " + Marshal.PtrToStringAnsi(uv_version_string()));
            Console.WriteLine("SQLite version: " + Marshal.PtrToStringAnsi(sqlite3_libversion()));
            //Console.WriteLine("Getting non-existent function: " + NonExistentMethods.sqlite3_get_number());
            //Console.WriteLine("Getting non-existent function: " + NonExistentMethods.get_number());
        }

        private static bool isMonoDarwin()
        {
            var runtimeEnvironment = PlatformServices.Default.Runtime;
            return runtimeEnvironment.OperatingSystem == "Darwin" && runtimeEnvironment.RuntimeType == "Mono";
        }

        private static IntPtr sqlite3_libversion()
        {
            return _isMonoDarwin ? SQLiteMethodsMonoDarwin.sqlite3_libversion() : SQLiteMethods.sqlite3_libversion();
        }
        
        private static IntPtr uv_version_string()
        {
            return _isMonoDarwin ? LibuvMethodsMonoDarwin.uv_version_string() : LibuvMethods.uv_version_string();
        }
        
        private static int get_number()
        {
            return _isMonoDarwin ? NativeMethodsMonoDarwin.get_number() : NativeMethods.get_number();
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
    
    public static class SQLiteMethodsMonoDarwin
    {
        [DllImport("__Internal")]
        public static extern IntPtr sqlite3_libversion();
    }

    public static class LibuvMethodsMonoDarwin
    {
        [DllImport("__Internal")]
        public static extern IntPtr uv_version_string();
    }

    public static class NativeMethodsMonoDarwin
    {
        [DllImport("__Internal")]
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
