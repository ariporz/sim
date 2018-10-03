using System;

namespace sim.Engine
{
    public class InputReceivedEventArgs : EventArgs
    {
        public int Player { get; set; }
        public int InputKey { get; set; }
    }

    public class Input
    {
        public event EventHandler<InputReceivedEventArgs> InputReceived;

        public void GetPlayerInput()
        {
            var pResult = -1;
            var iResult = -1;

            Console.WriteLine();
            Console.Write("Player: ");
            var player = Console.ReadLine();

            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.WriteLine($"P: {player}, I: {input}");

            if (int.TryParse(player, out pResult) && int.TryParse(input, out iResult))
            {
                InputReceivedEventArgs args = new InputReceivedEventArgs();
                args.Player = pResult;
                args.InputKey = iResult;
                OnInputReceived(args);
            }
        }

        protected virtual void OnInputReceived(InputReceivedEventArgs e)
        {
            InputReceived?.Invoke(this, e);
        }
    }
}