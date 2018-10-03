using System;

namespace sim.Engine
{
    // public abstract class Context
    // {
    //     public event EventHandler StateChanged;
    //     //public abstract event EventHandler GetPlayerInput;

    //     public abstract State CurrentState { get; set; }

    //     public abstract void Run();

    //     // public abstract void AskForInput();

    //     protected void OnStateChanged(State newState)
    //     {
    //         StateChanged?.Invoke(newState, EventArgs.Empty);
    //     }
    // }

    // public abstract class State
    // {
    //     protected GameContext context;

    //     public event EventHandler StateEvent;

    //     public GameContext Context
    //     {
    //         get => context;
    //         set => context = value;
    //     }

    //     public string GetName()
    //     {
    //         return this.ToString();
    //     }

    //     protected abstract void Entering();
    //     public abstract void Running();
    //     protected abstract void Exiting();
    //     public abstract void UserInput(string userId, string input);

    //     protected void OnStateEvent(State state)
    //     {
    //         StateEvent?.Invoke(this, EventArgs.Empty);
    //     }
    // }
}