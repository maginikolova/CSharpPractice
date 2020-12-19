using HypoportZooTask.CLI.Core.Contracts;
using System;

namespace HypoportZooTask.CLI.Core.Providers
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine(input);
        }
    }

}
