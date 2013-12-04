using System;
using System.Reflection;

[assembly: System.Reflection.AssemblyVersion("1.1.0.0")]

namespace UsefulStuff
{
    public class Test
    {
        public void PrintVersion()
        {
            Console.WriteLine("UsefulStuff Version = {0}", (Assembly.GetExecutingAssembly()).ToString());
        }
    }
}
