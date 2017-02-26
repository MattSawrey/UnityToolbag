using UnityEngine;
using System.Collections.Generic;

public enum States
{
    idle,
    Moving,
    Jumping
}

public enum Commands
{
    Rest,
    Move,
    Jump
}

public class StateMachine
{
    class StateTransition
    {
        public States CurrentState { get; private set; }
        public Commands Command { get; private set; }

        public StateTransition(States state, Commands command)
        {
            CurrentState = state;
            Command = command;
        }

        //Override hashcode and equals methods to ensure that the assigned hashcode never clashes
        //Remember to use prime numbers
        public override int GetHashCode()
        {
            return 17 + 31 * CurrentState.GetHashCode() + 17 * Command.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            StateTransition other = obj as StateTransition;
            return other != null && other.CurrentState == this.CurrentState && other.Command == this.Command;
        }
    }

    //Transitions dictionary
    Dictionary<StateTransition, States> transitions;
    public States CurrentState;

    //Constructor for the class
    public StateMachine(States startingState)
    {
        //Assignt the starting state
        CurrentState = startingState;

        //Fill the dictionary with all of the possible transitions
        transitions = new Dictionary<StateTransition, States>
            {
                {new StateTransition(States.idle, Commands.Jump), States.Jumping},
                {new StateTransition(States.idle, Commands.Jump), States.Jumping},
                {new StateTransition(States.idle, Commands.Jump), States.Jumping},
                {new StateTransition(States.idle, Commands.Jump), States.Jumping}
            };
    }

    public States GetNext(Commands command)
    {
        StateTransition transition = new StateTransition(CurrentState, command);
        States state;

        //Check whether the disctionary of transitions has the avaliable state transition requested
        if (!transitions.TryGetValue(transition, out state))
            Debug.Log("Cannot Transition");

        return state;
    }

    public States MoveNext(Commands command)
    {
        CurrentState = GetNext(command);
        return CurrentState;
    }
}

