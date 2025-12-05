using UnityEngine;
using Utilities.StateMachineSystem.Interfaces;

namespace Player.PlayerStates
{
    public class MovingPlayerState : IFixedUpdatableState
    {
        public void OnEnter()
        {
            Debug.Log("Entering Moving");
        }

        public void OnExit()
        {
            // to be done
        }

        public void OnUpdate()
        {
            // to be done
        }

        public void OnFixedUpdate()
        {
            // to be done
        }

        public void CheckTransition()
        {
            // to be done
        }
    }
}
