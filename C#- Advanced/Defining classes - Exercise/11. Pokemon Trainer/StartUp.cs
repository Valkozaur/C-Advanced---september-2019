namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var trainers = new HashSet<Trainer>();

            while (true)
            {
                var inputArgs = Console.ReadLine()
                    .Split(" ");

                if (inputArgs[0] == "Tournament")
                {
                    break;
                }

                var trainerName = inputArgs[0];
                var pokemonName = inputArgs[1];
                var pokemonElement = inputArgs[2];
                var pokemonHealth = int.Parse(inputArgs[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    var pokemons = new List<Pokemon>();
                    pokemons.Add(pokemon);

                    var trainer = new Trainer(trainerName, 0, pokemons);
                    trainers.Add(trainer);
                }
                else
                {
                    var trainer = trainers.FirstOrDefault(x => x.Name == trainerName);
                    trainer.Pokemons.Add(pokemon);
                }
            }

            while (true)
            {
                var inputArgs = Console.ReadLine()
                    .Split(" ");

                if (inputArgs[0] == "End")
                {
                    break;
                }

                var element = inputArgs[0];

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons
                            .Select(x => x.Health -= 10)
                            .ToList();

                        trainer.Pokemons = trainer.Pokemons
                            .Where(x => x.Health > 0)
                            .ToList();
                    }
                }
            }

            trainers = trainers
                .OrderByDescending(x => x.Badges)
                .ToHashSet();

            Console.WriteLine(String.Join(Environment.NewLine, trainers));
        }
    }
}
