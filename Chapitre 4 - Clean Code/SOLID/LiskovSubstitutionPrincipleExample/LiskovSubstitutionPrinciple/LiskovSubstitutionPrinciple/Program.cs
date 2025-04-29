using System;

namespace LiskovSubstitutionPrinciple // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BirdFlying> birds = new List<BirdFlying>
            {
                new Falcon("rouge")
            };

            foreach (BirdFlying bird in birds)
            {
                bird.Fly();
            }
        }
    }
}