using System;
using System.Collections.Generic;
using System.Text;

namespace HypoportZooTask.Models.Abstracts
{
    public abstract class Animal
    {
        // Properties
        public int Health { get; set; } = 100;

        // Methods
        /// <summary>
        /// Feeds the animal, increasing it's health with a random 10-25 value
        /// </summary>
        /// <returns>The animal's health</returns>
        public int Feed(int food)
        {
            this.Health = this.Health + food > 100 ? 100 : this.Health + food;
            return this.Health;
        }

        /// <summary>
        /// Makes the animal hungry, decreasing it's health with a random 15-35 value
        /// </summary>
        /// <returns>The animal's health</returns>
        public abstract int GetHungry(int hunger);

        /// <summary>
        /// Checks whether the animal is dead
        /// </summary>
        /// <returns>True/false of whether the animal is dead</returns>
        //public abstract bool CheckIfDead();
    }
}
