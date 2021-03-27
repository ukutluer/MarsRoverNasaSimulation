using MarsRoverNasaSimulation.Common.Models;
using System;

namespace MarsRoverNasaSimulation.Interfaces
{
    public interface IRoverSimulator
    {
        string CalculateRoverPosition(Tuple<RoverPosition, string> roverAndMoves, int maxXCoordinate, int maxYCoordinate);
    }
}
