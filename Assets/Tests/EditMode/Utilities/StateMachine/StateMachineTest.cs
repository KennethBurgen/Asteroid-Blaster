using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using Utilities.StateMachine.Interfaces;

namespace Tests.EditMode.Utilities.StateMachine
{
    public class StateMachineTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void StateMachineTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator StateMachineTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
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
