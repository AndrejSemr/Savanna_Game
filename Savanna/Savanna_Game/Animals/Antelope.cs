namespace Savanna.Savanna.Animals
{
    public class Antelope : Herbivores
    {
        public Antelope(IPlayground playground) : base(playground)
        {
            AnimalTypeLabel = 'A';
            AnimalType= "Antelope";

            maximumHealth = 40;
            Health = maximumHealth;
            VisionRange = 3;
        }

        public Antelope(IPlayground playground, int currentPositionX, int currentPositionY, int rangeX, int rangeY)
        : base(playground, currentPositionX, currentPositionY, rangeX, rangeY)
        {
        }
    }
}
