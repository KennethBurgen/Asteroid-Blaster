using System.Collections;
using NUnit.Framework;
using Systems;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.EditMode.Systems
{
    public class ObjectPoolManagerTest
    {
        private ObjectPoolManager _objectPoolManager;
        private GameObject _managingObj;

        [SetUp]
        public void Setup()
        {
            _managingObj = new GameObject("ManagingObj");
            _objectPoolManager = _managingObj.AddComponent<ObjectPoolManager>();
            _objectPoolManager.InitializeSingleton();
            _objectPoolManager.SetupEmpties();
        }

        [TearDown]
        public void TearDown()
        {
            ObjectPoolManager.ResetSingletonForTests();
            Object.DestroyImmediate(_managingObj);

            // Alle übrigen Gameobjects zerstören
            foreach (var obj in Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None))
            {
                Object.DestroyImmediate(obj);
            }
        }

        [Test]
        public void GetParentObjectOfGameObjects()
        {
            GameObject resultObj = _objectPoolManager.GetParentObject(
                ObjectPoolManager.PoolType.Gameobject
            );

            Assert.IsNotNull(resultObj);
            Assert.AreEqual(ObjectPoolManager._gameObjectsEmpty, resultObj);
        }

        [Test]
        public void ReturnObjectToPoolNoMatchingPool()
        {
            var fakeGO = new GameObject("FakeObject(Clone)");
            fakeGO.SetActive(true);

            LogAssert.Expect(
                LogType.Warning,
                "Trying to release an object that is not pooled: " + fakeGO.name
            );

            ObjectPoolManager.Instance.ReturnObjectToPool(fakeGO);

            Assert.AreEqual(fakeGO.activeInHierarchy, true, "Gameobject is still active");
        }
    }
}
