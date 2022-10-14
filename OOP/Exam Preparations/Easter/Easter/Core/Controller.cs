namespace Easter.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Bunnies;
    using Models.Bunnies.Contracts;
    using Models.Dyes;
    using Models.Eggs;
    using Models.Eggs.Contracts;
    using Models.Workshops;
    using Models.Workshops.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly BunnyRepository bunnies;
        private readonly EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = bunnyType switch
            {
                nameof(HappyBunny) => new HappyBunny(bunnyName),
                nameof(SleepyBunny) => new SleepyBunny(bunnyName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType)
            };

            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            Dye dye = new Dye(power);
            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var suitableBunnies = bunnies.Models
                .Where(e => e.Energy >= 50)
                .OrderByDescending(e => e.Energy);

            if (!suitableBunnies.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IEgg egg = eggs.FindByName(eggName);
            IWorkshop workshop = new Workshop();

            foreach (var bunny in suitableBunnies)
            {
                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            string doneOrNot = egg.IsDone()
                ? string.Format(OutputMessages.EggIsDone, eggName)
                : string.Format(OutputMessages.EggIsNotDone, eggName);

            return doneOrNot;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            int coloredEggs = eggs.Models.Count(e => e.IsDone());

            sb
                .AppendLine($"{coloredEggs} eggs are done!")
                .AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                int dyesNotFinished = bunny.Dyes.Count(d => !d.IsFinished());

                sb
                    .AppendLine($"Name: {bunny.Name}")
                    .AppendLine($"Energy: {bunny.Energy}")
                    .AppendLine($"Dyes: {dyesNotFinished} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}