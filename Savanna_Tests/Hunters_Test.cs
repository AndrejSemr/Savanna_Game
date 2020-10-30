using AnimalsBase;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Savanna_Tests
{
    public class Hunters_Test
    {
        private Hunters _hunters;

        public Hunters_Test()
        {
            _hunters = new Hunters(2, 2);
        }

        [Fact]
        public void EatTarget_TargetId_HunterEatTarget()
        {
            List<Herbivores> herbivores = new List<Herbivores>();
            List<Hunters> hunters = new List<Hunters>();
            char[,] array = new char[2, 2];

            herbivores.Add(new Herbivores(2, 2) {XPaygroundCoordinate = 0, YPaygroundCoordinate = 0 });
            _hunters.Health = 10;
            _hunters.XPaygroundCoordinate = 0;
            _hunters.YPaygroundCoordinate = 1;

            Assert.Single(herbivores);
            _hunters.SpecialAnimalBehavior(hunters,herbivores, array);
            Assert.Empty(herbivores);
        }
    }
}
