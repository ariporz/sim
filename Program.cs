using System;
using sim.Engine;

namespace sim
{
    class Program
    {
        public static GameContext gameContext = new GameContext();

        static void Main(string[] args)
        {
            Input input = new Input();
            input.InputReceived += gameContext_InputReceived;

            gameContext.StateChanged += gameContext_StateChanged;

            while (!gameContext.Exit)
            {
                gameContext.Run();
            }
        }

        static void gameContext_StateChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"State Changed: {((State)sender).GetName()}");
        }

        static void gameContext_InputReceived(object sender, InputReceivedEventArgs e)
        {
            Console.WriteLine($"Input reveived: {e.Player}, {e.InputKey}");
            gameContext.CurrentState.UserInput(e.Player, e.InputKey);
        }
    }
}
