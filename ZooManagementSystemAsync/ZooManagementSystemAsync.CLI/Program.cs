using HypoportZooTask.CLI.Core;
using HypoportZooTask.CLI.Core.Contracts;
using HypoportZooTask.CLI.Core.Providers;
using System;

namespace HypoportTask.CLI
{
    class Program
    {
        private readonly static IConsoleWriter writer = new ConsoleWriter();
        private readonly static IConsoleReader reader = new ConsoleReader();

        private readonly static Random rnd = new Random();
        private readonly static Zoo zoo = new Zoo(rnd);
        private readonly static Engine engine = new Engine(zoo, writer, reader);

        static void Main(string[] args)
        {
            engine.Run();
        }
    }
}
