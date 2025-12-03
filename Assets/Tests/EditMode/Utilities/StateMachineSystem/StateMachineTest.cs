using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine.TestTools;
using Utilities.StateMachineSystem;
using Utilities.StateMachineSystem.Interfaces;

namespace Tests.EditMode.Utilities.StateMachineSystem
{
    public class StateMachineTest
    {
        [Test]
        public void StateMachineTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        private class ExampleUpdatableState : IUpdatableState
        {
            // ACHTUNG: Hier wahrscheinlich sinnvoller moq-Framework zu implementieren und zu verwenden
            public void OnEnter() { }

            public void OnExit() { }

            public void OnUpdate() { }
        }
    }
}
