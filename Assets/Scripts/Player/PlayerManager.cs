using UnityEngine;
using Utilities.StateMachineSystem;
using Utilities.StateMachineSystem.Interfaces;

public class PlayerManager : MonoBehaviour
{
    // Referenzen
    internal IStateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();
    }
}
