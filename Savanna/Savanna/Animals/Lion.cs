namespace Savanna.Savanna.Animals
{
    public class Lion : Hunters
    {
        public Lion(IPlayground playground):base(playground)
        {
            maximumHealth = 20;
            Health = maximumHealth;
            VisionRange = 6;
        }
    }
}
