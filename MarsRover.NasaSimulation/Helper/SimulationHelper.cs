using MarsRoverNasaSimulation.Common.Models;
using MarsRoverNasaSimulation.Implementations;
using MarsRoverNasaSimulation.Interfaces;
using System;

namespace MarsRoverNasaSimulation.Helper
{
    public class SimulationHelper
    {
        private readonly IRoverSimulator roverSimulator;
        public int MaxXCoordinate,MaxYCoordinate;
        public SimulationHelper()
        {
            roverSimulator = new RoverSimulator();
        }
        /// <summary>
        /// Start simulation
        /// </summary>
        public void Simulate()
        {
            initializeSurfaceMap();
            var firstUserAndMoves = getRoverAndMoves();
            var secordUserAndMoves = getRoverAndMoves(); 
            string resultOfFirstRover = roverSimulator.CalculateRoverPosition(firstUserAndMoves, MaxXCoordinate, MaxYCoordinate);
            string resultOfSecondRover = roverSimulator.CalculateRoverPosition(secordUserAndMoves, MaxXCoordinate, MaxYCoordinate);
            Console.WriteLine(resultOfFirstRover);
            Console.WriteLine(resultOfSecondRover);
            Console.ReadLine();
        }

        /// <summary>
        /// Initialize surface map max x & y coordinates
        /// </summary>
        private void initializeSurfaceMap()
        {
            string[] surfaceIndexs = getSafeStringFromUser();
            int.TryParse(surfaceIndexs[0], out MaxXCoordinate);
            int.TryParse(surfaceIndexs[1], out MaxYCoordinate);
        }

        /// <summary>
        /// Simulate all moves according to user position step by step
        /// </summary>
        /// <param name="userAndMoves"> user last position and next moves</param>
        /// <returns></returns>


        /// <summary>
        /// Fill user and moves
        /// </summary>
        /// <returns></returns>
        private Tuple<RoverPosition, string> getRoverAndMoves()
        {
            RoverPosition user = getRoverDetailFromInput();
            string userMoves = getSafeStringFromUser()[0];
            return new Tuple<RoverPosition, string>(user, userMoves);
        }

        /// <summary>
        /// USer position and direction informations from input
        /// </summary>
        /// <returns></returns>
        private RoverPosition getRoverDetailFromInput()
        {
            string[] userInput = getSafeStringFromUser();
            int xCoor, yCoor;
            Direction direction;
            if(userInput == null || userInput.Length != 3)
            {
                throw new Exception($"Wrong user detail input:  { string.Join(' ', userInput)}");
            }
            if(!int.TryParse(userInput[0], out xCoor) || xCoor< 0 || xCoor > MaxXCoordinate)
            {
                throw new Exception($"OutofSurface for user coordinate X: {xCoor} , input: {userInput[0]}");
            }
            if (!int.TryParse(userInput[1], out yCoor) || yCoor < 0 || yCoor > MaxYCoordinate)
            {
                throw new Exception($"OutofSurface for user coordinate Y: {yCoor} , input: {userInput[1]}");
            }
            if(!Enum.TryParse<Direction>(userInput[2], out direction))
            {
                throw new Exception($"Unknown direction is {userInput[2]}");
            }    
            return new RoverPosition(xCoor, yCoor, direction);
        }

        /// <summary>
        /// Get Valid input from user
        /// </summary>
        /// <returns></returns>
        private string[] getSafeStringFromUser()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine().Trim().ToUpper();
                if (!string.IsNullOrEmpty(input))
                {
                    return input.Split(' ');
                }
                Console.WriteLine("Please enter valid values");
            }
        }
    }
}
