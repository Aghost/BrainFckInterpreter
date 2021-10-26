using System;
using BrainFck.Core;
using static System.Console;

namespace BrainFck.App
{
    class Program
    {
        static readonly string HelloWorld = "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.";
        static void Main(string[] args)
        {
            BrainFckInterpreter BFI = args.Length < 1 ? new(HelloWorld) : new(String.Join(" ", args));

            BFI.Run();
        }
    }

}
