using System;
using sim.Engine;

namespace sim
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContext gameContext = new GameContext();

            gameContext.Run();
            gameContext.Run();
            gameContext.Run();
            gameContext.Run();
        }
    }
}
