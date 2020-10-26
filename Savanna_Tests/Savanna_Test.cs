using Savanna;
using Savanna.Savanna;
using Savanna.Savanna.Animals;
using System;
using Xunit;

namespace Savanna_Tests
{
    public class Savanna_Test
    {
        private ISavanna _sut;
        private IPlayground _playground;
        public Savanna_Test()
        {
            _sut = new SavannaEngine();

            _playground = new Playground(20, 20);
            _playground.ZerroArray();
        }

        [Fact]
        public void NumbersOfAnimals_AddAnimalsFollowCounter_CounterShowsCorrectValues()
        {
            Antelope antelope1 = new Antelope(_playground) { XPaygroundCoordinate = 2, YPaygroundCoordinate = 2};
            Antelope antelope2 = new Antelope(_playground) { XPaygroundCoordinate = 1, YPaygroundCoordinate = 2 };
            Lion lion = new Lion(_playground) { XPaygroundCoordinate = 5, YPaygroundCoordinate = 5 };

            Assert.Equal(0,_sut.NumbersOfAnimals().Item1);
            Assert.Equal(0, _sut.NumbersOfAnimals().Item2);

            _sut.AddHerbivores(antelope1);
            Assert.Equal(1, _sut.NumbersOfAnimals().Item2);

            _sut.AddHerbivores(antelope2);
            Assert.Equal(2, _sut.NumbersOfAnimals().Item2);

            _sut.AddHunters(lion);
            Assert.Equal(1, _sut.NumbersOfAnimals().Item1);
            Assert.Equal(2, _sut.NumbersOfAnimals().Item2);
        }

        [Fact]
        public void NumbersOfAnimals_AppearanceOfChild_CounterGoUp() {
            Antelope antelope1 = new Antelope(_playground) { XPaygroundCoordinate = 2, YPaygroundCoordinate = 2 };
            Antelope antelope2 = new Antelope(_playground) { XPaygroundCoordinate = 1, YPaygroundCoordinate = 2 };
            Lion lion = new Lion(_playground) { XPaygroundCoordinate = 5, YPaygroundCoordinate = 5 };

            Assert.Equal(0, _sut.NumbersOfAnimals().Item1);

            _sut.AddHerbivores(antelope1);
            _sut.AddHerbivores(antelope2);
            Assert.Equal(2, _sut.NumbersOfAnimals().Item2);


            _sut.Iteration(_playground);
            _sut.Iteration(_playground);
            _sut.Iteration(_playground);
            Assert.Equal(3, _sut.NumbersOfAnimals().Item2);
        }
    }
}
