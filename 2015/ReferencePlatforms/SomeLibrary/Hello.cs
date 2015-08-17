using System;

namespace SomeLibrary
{
    public class Hello
    {
        public void Say()
        {
            Console.WriteLine("START");

#if ANYCPU
            Console.WriteLine("AnyCPU");
#endif

#if X64
            Console.WriteLine("X64");
#endif

#if X86
            Console.WriteLine("X86");
#endif

            Console.WriteLine("STOP");
        }
    }
}