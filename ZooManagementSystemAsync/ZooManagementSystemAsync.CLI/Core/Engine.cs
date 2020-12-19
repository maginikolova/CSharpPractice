using HypoportZooTask.CLI.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HypoportZooTask.CLI.Core
{
    public class Engine
    {
        public Engine(Zoo zoo, IConsoleWriter writer, IConsoleReader reader)
        {
            Zoo = zoo;
            Writer = writer;
            Reader = reader;
        }

        private Random Rnd { get; }
        private Zoo Zoo { get; }
        private IConsoleWriter Writer { get; }
        private IConsoleReader Reader { get; }

        public void Run()
        {
            var command = "";

            while (command.Split()[0] != "exit")
            {
                // Draw console
                DrawConsoleCommands();

                // Get current command
                command = this.Reader.ReadLine();

                // Request the command result
                var commandResultTask = ParseCommand(command);
                // This also works (ParseCommand should return only string though)
                // var commandResultTask = Task.Run(() => ParseCommand(command));

                // Just in case the task is done almost completely
                System.Threading.Thread.Sleep(100);

                // Loading screen
                while (!commandResultTask.IsCompleted)
                {
                    this.Writer.WriteLine(". ");
                    System.Threading.Thread.Sleep(400);
                }

                // Write the command result
                this.Writer.WriteLine(Environment.NewLine + commandResultTask.Result);

                // Clear console and get new command
                this.Writer.WriteLine("Press ENTER button to continue");
                this.Reader.ReadLine();
                Console.Clear();
            }
        }

        private void DrawConsoleCommands()
        {
            this.Writer.WriteLine("seeanimals");
            this.Writer.WriteLine("feedanimals");
            this.Writer.WriteLine("makeanimalshungry");
            this.Writer.WriteLine("animalsalive");
            this.Writer.WriteLine("minhealth [species]");
            this.Writer.WriteLine("help");
            this.Writer.WriteLine("exit");
            this.Writer.WriteLine("====================================================" + Environment.NewLine);
        }

        private Task<string> ParseCommand(string command)
            => (command.Split()[0]) switch
            {
                "seeanimals" => this.Zoo.SeeAnimals(),
                "feedanimals" => this.Zoo.FeedAnimals(),
                "makeanimalshungry" => this.Zoo.MakeAnimalsHungry(),
                "animalsalive" => this.Zoo.CheckAnimalsAlive(),
                "minhealth [species]" => this.Zoo.CheckMinHealthOfSpecies(),

                _ => Task.FromResult("Command does not exist")
            };
    }
}