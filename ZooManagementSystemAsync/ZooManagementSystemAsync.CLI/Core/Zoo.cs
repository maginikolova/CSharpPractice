using HypoportZooTask.Models;
using HypoportZooTask.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypoportZooTask.CLI.Core
{
    public class Zoo
    {
        private IList<Animal> Animals;

        public Zoo(Random rnd)
        {
            this.Rnd = rnd;

            this.Animals = new List<Animal>
            {
                new Bear(),
                new Bear(),
                new Bear(),
                new Bear(),
                new Bear(),
                new Bear(),
                new Bear(),
                new Bear(),
                new Bear(),
                new Bear(),

                new Giraffe(),
                new Giraffe(),
                new Giraffe(),
                new Giraffe(),
                new Giraffe(),
                new Giraffe(),
                new Giraffe(),
                new Giraffe(),
                new Giraffe(),
                new Giraffe(),

                new Monkey(),
                new Monkey(),
                new Monkey(),
                new Monkey(),
                new Monkey(),
                new Monkey(),
                new Monkey(),
                new Monkey(),
                new Monkey(),
                new Monkey()
            };
        }

        private Random Rnd { get; }

        /// <summary>
        /// Get a list of all the animals in the zoo and their health
        /// </summary>
        /// <returns></returns>
        public Task<string> SeeAnimals()
            => Task<string>.Factory.StartNew(() =>
            {
                var sb = new StringBuilder();

                foreach (var animal in this.Animals)
                {
                    sb.AppendLine(animal.ToString());
                }

                return String.IsNullOrEmpty(sb.ToString()) ? "There are no animals in the zoo" : sb.ToString();
            });

        /// <summary>
        /// Feeds top 90% (using floor rounding) of animals in the zoo, 
        /// sorted by health in desc order
        /// </summary>
        /// <returns></returns>
        public Task<string> FeedAnimals()
            => Task<string>.Factory.StartNew(() =>
            {
                if (this.Animals == null)
                {
                    return "No animals to feed";
                }

                var animalsToFeedCount = Convert.ToInt32(Math.Floor(0.9 * this.Animals.Count()));
                var animalsToFeed = this.Animals.OrderByDescending(a => a.Health)
                    .Take(animalsToFeedCount);

                var food = 0;
                foreach (var animal in this.Animals)
                {
                    food = this.Rnd.Next(10, 25);
                    animal.Feed(food);
                }

                return "Animals fed";
            });

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<string> MakeAnimalsHungry()
            => Task<string>.Factory.StartNew(() =>
            {
                var animalsHunger = new Dictionary<Type, int>
                {
                    [typeof(Bear)] = this.Rnd.Next(15, 35),
                    [typeof(Giraffe)] = this.Rnd.Next(15, 35),
                    [typeof(Monkey)] = this.Rnd.Next(15, 35)
                };

                int deathCount = 0;

                foreach (var animal in this.Animals)
                {
                    int currAnimalHealth = 0;

                    currAnimalHealth = animal.GetHungry(animalsHunger[animal.GetType()]);

                    if (currAnimalHealth == 0)
                    {
                        deathCount++;
                    }
                }

                this.Animals = this.Animals.Where(a => a.Health != 0).ToList();

                return $"{deathCount} animals died";
            });

        public Task<string> CheckAnimalsAlive()
            => Task<string>.Factory.StartNew(() =>
            {
                return this.Animals.Count.ToString();
            });

        public Task<string> CheckMinHealthOfSpecies()
            => Task<string>.Factory.StartNew(() =>
            {
                return this.Animals.Select(a => a.Health).Min().ToString();
            });
    }
}


/*      // Another way of adding items to Dictionary<>
 
            var dict = new Dictionary<Type, int>
            {
                {
                    typeof(Bear), this.Rnd.Next(15, 35)
                },
                {
                    typeof(Giraffe), this.Rnd.Next(15, 35)
                },
                {
                    typeof(Monkey), this.Rnd.Next(15, 35)
                }
            };
*/
