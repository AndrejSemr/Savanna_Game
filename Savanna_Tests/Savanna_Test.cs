using AnimalDllCreator;
using Animal;
using Savanna;
using Savanna.Savanna;
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
            Antelope antelope1 = new Antelope(2,2) { XPaygroundCoordinate = 2, YPaygroundCoordinate = 2};
            Antelope antelope2 = new Antelope(2,2) { XPaygroundCoordinate = 1, YPaygroundCoordinate = 2 };
            Lion lion = new Lion(2,2) { XPaygroundCoordinate = 5, YPaygroundCoordinate = 5 };

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
            Antelope antelope1 = new Antelope(2,2) { XPaygroundCoordinate = 2, YPaygroundCoordinate = 2 };
            Antelope antelope2 = new Antelope(2,2) { XPaygroundCoordinate = 1, YPaygroundCoordinate = 2 };

            Assert.Equal(0, _sut.NumbersOfAnimals().Item1);

            _sut.AddHerbivores(antelope1);
            _sut.AddHerbivores(antelope2);
            Assert.Equal(2, _sut.NumbersOfAnimals().Item2);


            _sut.Iteration(_playground);
            _sut.Iteration(_playground);
            _sut.Iteration(_playground);
            Assert.Equal(3, _sut.NumbersOfAnimals().Item2);
        }

        [Theory]
        [InlineData(ConsoleKey.A, typeof(Antelope))]
        [InlineData(ConsoleKey.P, typeof(Pig))]
        public void GeneratNewAnimals_SendHebrivorceButton_NewAnimalAppears(ConsoleKey kay,Type type)
        {
            _sut.GeneratNewAnimals(2, 2, kay);
            var listOfAnimals = _sut.GetListOfHerbivores();
            Assert.Single(listOfAnimals);
            Assert.Equal(type, listOfAnimals[0].GetType());


            _sut.GeneratNewAnimals(2, 2, kay);
            listOfAnimals = _sut.GetListOfHerbivores();
            Assert.Equal(2, listOfAnimals.Count);
            Assert.Equal(type, listOfAnimals[1].GetType());
        }

        [Theory]
        [InlineData(ConsoleKey.L, typeof(Lion))]
        [InlineData(ConsoleKey.T, typeof(Tiger))]
        public void GeneratNewAnimals_SendHunterButton_NewAnimalAppears(ConsoleKey kay, Type type)
        {
            _sut.GeneratNewAnimals(2, 2, kay);
            var listOfAnimals = _sut.GetListOfHunters();
            Assert.Single(listOfAnimals);
            Assert.Equal(type, listOfAnimals[0].GetType());


            _sut.GeneratNewAnimals(2, 2, kay);
            listOfAnimals = _sut.GetListOfHunters();
            Assert.Equal(2, listOfAnimals.Count);
            Assert.Equal(type, listOfAnimals[1].GetType());
        }

        [Fact]
        public void GeneratNewAnimals_SendWrongButtonButton_Nothing()
        {
            _sut.GeneratNewAnimals(2, 2, ConsoleKey.UpArrow);

            Assert.Empty(_sut.GetListOfHunters());
            Assert.Empty(_sut.GetListOfHerbivores());
        }

        [Fact]
        public void AnimalHealthCheck_AnimalWithoutHealth_AnimalDies()
        {

            Antelope antelope = new Antelope(2, 2) { Health = 0 };
            _sut.AddHerbivores(antelope);

            Assert.Single(_sut.GetListOfHerbivores());
            _sut.Iteration(_playground);
            Assert.Empty(_sut.GetListOfHerbivores());
        }

        [Fact]
        public void SetNewPlayground_AddAnimal_AnimalAppearsOnPlayground()
        {
            Antelope antelope1 = new Antelope(2, 2) { XPaygroundCoordinate = 0, YPaygroundCoordinate = 0 };
            Lion lion = new Lion(2, 2) { XPaygroundCoordinate = 1, YPaygroundCoordinate = 1 };

            _sut.AddHerbivores(antelope1);
            _sut.AddHunters(lion);
            _sut.UpdatePlayground(_playground);

            char[,] arrays = _playground.GetPlaygroundArray();
            Assert.Equal('A', arrays[0, 0]);
            Assert.Equal('L',arrays[1, 1]);
        }
    }
}
