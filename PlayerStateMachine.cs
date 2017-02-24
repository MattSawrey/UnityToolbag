using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Players 
{

	public enum PlayerStates
	{
		idle,
		Moving,
		Jumping
	}

	public enum TransitionCommands
	{
		Rest,
		Move,
		Jump
	}

	public class PlayerStateMachine
	{
		class StateTransition
		{
			public PlayerStates CurrentState{get; private set;}
			public TransitionCommands Command{get; private set;}

			public StateTransition(PlayerStates state, TransitionCommands command)
			{
				CurrentState = state;
				Command = command;
			}

			//Override hashcode and equals methods to ensure that the assigned hashcode never clashes
			//Remember to use prime numbers
			public override int GetHashCode ()
			{
				return 17 + 31 * CurrentState.GetHashCode() + 17 * Command.GetHashCode();
			}

			public override bool Equals (object obj)
			{
				StateTransition other = obj as StateTransition;
				return other != null && other.CurrentState == this.CurrentState && other.Command == this.Command;
			}
		}

		//Transitions dictionary
		Dictionary<StateTransition, PlayerStates> transitions;
		public PlayerStates CurrentState;

		//Constructor for the class
		public PlayerStateMachine(PlayerStates startingState)
		{
			//Assignt the starting state
			CurrentState = startingState;

			//Fill the dictionary with all of the possible transitions
			transitions = new Dictionary<StateTransition, PlayerStates>
			{
				{new StateTransition(PlayerStates.idle, TransitionCommands.Jump), PlayerStates.Jumping},
				{new StateTransition(PlayerStates.idle, TransitionCommands.Jump), PlayerStates.Jumping},
				{new StateTransition(PlayerStates.idle, TransitionCommands.Jump), PlayerStates.Jumping},
				{new StateTransition(PlayerStates.idle, TransitionCommands.Jump), PlayerStates.Jumping}
			};
		}

		public PlayerStates GetNext(TransitionCommands command)
		{
			StateTransition transition = new StateTransition(CurrentState, command);
			PlayerStates state;

			//Check whether the disctionary of transitions has the avaliable state transition requested
			if(!transitions.TryGetValue(transition, out state))
			   Debug.Log("Cannot Transition");

			return state;			  
		}

		public PlayerStates MoveNext(TransitionCommands command)
		{
			CurrentState = GetNext(command);
			return CurrentState;
		}
	}

}
