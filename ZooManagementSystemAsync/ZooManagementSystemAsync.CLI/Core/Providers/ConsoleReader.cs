using HypoportZooTask.CLI.Core.Contracts;
using System;

namespace HypoportZooTask.CLI.Core.Providers
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
            => Console.ReadLine();
    }
}
