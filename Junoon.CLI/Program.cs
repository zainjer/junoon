using System;
using Junoon.Core;

namespace Junoon.CLI
{
    class Program
    {
        private static ForLoop forloop;
        static void Main(string[] args)
        {
            var iterator = new Iterator(Iterator.IteratorSign.Negative, 1);
            
            forloop = new ForLoop(iterator,2,ForLoop.LoopCondition.LessThan,0,MyTestingMethod);
            forloop.IterateAll();
        }

        static void MyTestingMethod()
        {
            Console.WriteLine(forloop.CurrentIndex);
        }
        
    }
}