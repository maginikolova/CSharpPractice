using HypoportZooTask.Models.Abstracts;
using System;

namespace HypoportZooTask.Models
{
    public class Monkey : Animal
    {
        public override int GetHungry(int hunger)
            => this.Health - hunger < 40 ? this.Health = 0 : this.Health -= hunger;

        public override string ToString()
        {
            return $"Monkey : {this.Health}";
        }
    }
}
