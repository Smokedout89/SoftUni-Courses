namespace Easter.Models.Workshops
{
    using System.Linq;
    using Bunnies.Contracts;
    using Contracts;
    using Eggs.Contracts;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            foreach (var dye in bunny.Dyes)
            {
                while (!dye.IsFinished())
                {
                    egg.GetColored();
                    bunny.Work();
                    dye.Use();

                    if (egg.IsDone())
                    {
                        break;
                    }
                }

                if (egg.IsDone())
                {
                    break;
                }

                if (bunny.Energy == 0)
                {
                    break;
                }

                if (bunny.Dyes.All(d => d.IsFinished()))
                {
                    break;
                }
            }
        }
    }
}