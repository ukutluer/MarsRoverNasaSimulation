using MarsRoverNasaSimulation.Helper;

namespace MarsRoverNasaSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulationHelper simulationHelper = new SimulationHelper();
            simulationHelper.Simulate();
        }
    }
}
