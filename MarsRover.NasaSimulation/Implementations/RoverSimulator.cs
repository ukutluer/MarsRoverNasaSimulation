using MarsRoverNasaSimulation.Common.Models;
using MarsRoverNasaSimulation.Interfaces;
using System;

namespace MarsRoverNasaSimulation.Implementations
{
    public class RoverSimulator : IRoverSimulator
    {
        public string CalculateRoverPosition(Tuple<RoverPosition, string> roverAndMoves, int maxXCoordinate, int maxYCoordinate)
        {
            var userPosition = roverAndMoves.Item1;
            string moves = roverAndMoves.Item2;
            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'M':
                        userPosition.MoveForward();
                        break;
                    case 'L':
                        userPosition.TurnLeft();
                        break;
                    case 'R':
                        userPosition.TurnRight();
                        break;
                    default:
                        Console.WriteLine($"Unknown move command => {moves[i]}");
                        break;

                }
                isValidPosition(userPosition, maxXCoordinate, maxYCoordinate);
            }
            return userPosition.ToString();
        }

        private static void isValidPosition(RoverPosition roverPosition, int maxXCoordinate, int maxYCoordinate)
        {
            if (roverPosition.CurrentXIndex > maxXCoordinate || roverPosition.CurrentXIndex < 0 || roverPosition.CurrentYIndex > maxYCoordinate || roverPosition.CurrentYIndex < 0)
                throw new Exception(string.Concat("OutOfSurface for user: ", roverPosition.ToString()));
        }
    }


}
