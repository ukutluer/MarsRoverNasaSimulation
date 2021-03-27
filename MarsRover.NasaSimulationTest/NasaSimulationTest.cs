using MarsRoverNasaSimulation.Common.Models;
using MarsRoverNasaSimulation.Implementations;
using MarsRoverNasaSimulation.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRoverNasaSimulationTest
{
    [TestClass]
    public class NasaSimulationTest
    {
        #region simuation tests
        [TestMethod]
        public void TestSenario_12N_LMLMLMLMM()
        {
            var expectedOutput = "1 3 N";
            var actualOutput = simulateRover(new RoverPosition(1, 2, Direction.N), "LMLMLMLMM", 5, 5);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestSenario_33E_MMRMMRMRRM()
        {
            var expectedOutput = "5 1 E";
            var actualOutput = simulateRover(new RoverPosition(3, 3, Direction.E), "MMRMMRMRRM", 5, 5);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        #endregion

        #region direction calculate tests
        [TestMethod]
        public void TestSenario_DirectionN_TurnLeft()
        {
            var expectedOutput = Direction.W;
            var userPosition = new RoverPosition(0, 0, Direction.N);
            userPosition.TurnLeft();
            var actualOutput =userPosition.Direction;
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void TestSenario_DirectionN_TurnRight()
        {
            var expectedOutput = Direction.E;
            var userPosition = new RoverPosition(0, 0, Direction.N);
            userPosition.TurnRight();
            var actualOutput = userPosition.Direction;
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestSenario_DirectionE_TurnLeft()
        {
            var expectedOutput = Direction.N;
            var userPosition = new RoverPosition(0, 0, Direction.E);
            userPosition.TurnLeft();
            var actualOutput = userPosition.Direction;
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void TestSenario_DirectionE_TurnRight()
        {
            var expectedOutput = Direction.S;
            var userPosition = new RoverPosition(0, 0, Direction.E);
            userPosition.TurnRight();
            var actualOutput = userPosition.Direction;
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestSenario_DirectionS_TurnLeft()
        {
            var expectedOutput = Direction.E;
            var userPosition = new RoverPosition(0, 0, Direction.S);
            userPosition.TurnLeft();
            var actualOutput = userPosition.Direction;
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void TestSenario_DirectionS_TurnRight()
        {
            var expectedOutput = Direction.W;
            var userPosition = new RoverPosition(0, 0, Direction.S);
            userPosition.TurnRight();
            var actualOutput = userPosition.Direction;
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void TestSenario_DirectionW_TurnLeft()
        {
            var expectedOutput = Direction.S;
            var userPosition = new RoverPosition(0, 0, Direction.W);
            userPosition.TurnLeft();
            var actualOutput = userPosition.Direction;
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]
        public void TestSenario_DirectionW_TurnRight()
        {
            var expectedOutput = Direction.N;
            var userPosition = new RoverPosition(0, 0, Direction.W);
            userPosition.TurnRight();
            var actualOutput = userPosition.Direction;
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        #endregion

        #region helper methods
        private string simulateRover(RoverPosition roverPosition, string moves, int maxXCoordinate, int maxYCoordinate)
        {
            IRoverSimulator roverSimulator = new RoverSimulator();
            return roverSimulator.CalculateRoverPosition(new Tuple<RoverPosition, string>(roverPosition, moves), maxXCoordinate, maxYCoordinate);
        }
        #endregion
    }
}
