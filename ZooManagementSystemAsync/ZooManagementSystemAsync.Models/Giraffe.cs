using HypoportZooTask.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypoportZooTask.Models
{
    public class Giraffe : Animal
    {
        public override int GetHungry(int hunger)
            => this.Health < 60 ? this.Health = 0 : this.Health -= hunger;

        public override string ToString()
        {
            return $"Giraffe : {this.Health}";
        }
    }
}
