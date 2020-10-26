namespace Savanna.Savanna.Animals
{
    public class Lion : Hunters
    {
        public Lion(IPlayground playground):base(playground)
        {
            AnimalTypeLabel = 'L';
            AnimalType = "Lion";

            maximumHealth = 10;
            Health = maximumHealth;
            VisionRange = 6;
        }

        public Lion(IPlayground playground, int currentPositionX, int currentPositionY, int rangeX, int rangeY)
                : base(playground, currentPositionX, currentPositionY, rangeX, rangeY)
        {
        }
    }
}
