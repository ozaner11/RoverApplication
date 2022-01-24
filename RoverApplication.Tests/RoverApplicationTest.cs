using NUnit.Framework;
using RoverApplication.Repository;

namespace RoverApplication.Tests
{
    public class RoverApplicationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void TestRover(string plateuSize,string roverPosition,string roverCommands,string Result )
        {
            Plateu plateu = new Plateu(plateuSize);
            Rover rover = new Rover(plateu, roverPosition);
             rover.Move(roverCommands.ToCharArray());
            Assert.AreEqual(Result,rover.GetCoordinates());
        }
    }
}