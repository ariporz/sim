using System;

namespace sim.Engine
{
    public class PlayerInput
    {
        public int GetPlayerInput()
        {
            var result = -1;
            var input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                Console.WriteLine($"Input: {input}");
            }
            return result;
        }
    }
}