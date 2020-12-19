using HypoportZooTask.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypoportZooTask.Models
{
    public class Bear : Animal
    {
        public override int GetHungry(int hunger)
            => this.Health - hunger < 65 ? this.Health = 0 : this.Health -= hunger;

        public override string ToString()
        {
            return $"Bear : {this.Health}";
        }
    }
}
