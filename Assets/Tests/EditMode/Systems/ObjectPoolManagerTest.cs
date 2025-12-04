using System.Linq;
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
            var fakeGo = new GameObject("FakeObject(Clone)");
            fakeGo.SetActive(true);

            LogAssert.Expect(
                LogType.Warning,
                "Trying to release an object that is not pooled: " + fakeGo.name
            );

            ObjectPoolManager.Instance.ReturnObjectToPool(fakeGo);

            Assert.AreEqual(true, fakeGo.activeInHierarchy, "Gameobject is still active");
        }

        [Test]
        public void ReturnObjectToPoolWithMatchingPool()
        {
            var fakeGo = new GameObject("FakeObject(Clone)");
            fakeGo.SetActive(true);

            var objectPool = ObjectPoolManager.Instance.FindOrCreateObjectPool(
                fakeGo.name.Substring(0, fakeGo.name.Length - 7)
            );

            ObjectPoolManager.Instance.ReturnObjectToPool(fakeGo);

            Assert.AreEqual(false, fakeGo.activeInHierarchy, "Gameobject is not active");
            Assert.IsNotEmpty(
                objectPool.InactiveObjects,
                "ObjectPool inactive objects list not empty"
            );
            Assert.AreEqual(
                fakeGo.name.Substring(0, fakeGo.name.Length - 7),
                objectPool.LookupString,
                "LookupString named correctly"
            );
            Assert.AreEqual(
                fakeGo.name,
                objectPool.InactiveObjects.First().name,
                "Inactive object same as fakeGo"
            );
        }

        [Test]
        public void DeactivateAllObjectsOk()
        {
            var fakeGo = new GameObject("FakeObject(Clone)");
            var fakeGo2 = new GameObject("FakeObject2(Clone)");
            fakeGo = ObjectPoolManager.Instance.SpawnObject(
                fakeGo,
                new Vector3(0, 0, 0),
                Quaternion.identity,
                ObjectPoolManager.PoolType.Gameobject
            );
            fakeGo2 = ObjectPoolManager.Instance.SpawnObject(
                fakeGo2,
                new Vector3(1, 1, 1),
                Quaternion.identity,
                ObjectPoolManager.PoolType.Gameobject
            );

            Assert.AreEqual(true, fakeGo.activeInHierarchy, "Gameobject is active");
            Assert.AreEqual(true, fakeGo2.activeInHierarchy, "Gameobject 2 is active");

            ObjectPoolManager.Instance.DeactivateAllObjects();
            Assert.AreEqual(false, fakeGo.activeInHierarchy, "Gameobject is not active");
            Assert.AreEqual(false, fakeGo2.activeInHierarchy, "Gameobject 2 is not active");
        }

        [Test]
        public void SpawnObjectNoInactiveObjectsOk()
        {
            var position = new Vector3(0, 0, 0);
            var rotation = Quaternion.identity;

            var fakeGo = new GameObject("FakeObject(Clone)");
            fakeGo = ObjectPoolManager.Instance.SpawnObject(
                fakeGo,
                position,
                rotation,
                ObjectPoolManager.PoolType.Gameobject
            );

            Assert.AreEqual(
                ObjectPoolManager._gameObjectsEmpty,
                fakeGo.transform.parent.gameObject,
                "Gameobject has correct parent"
            );

            Assert.AreEqual(position, fakeGo.transform.position, "Gameobject position matches");
            Assert.AreEqual(rotation, fakeGo.transform.rotation, "Gameobject rotation matches");
            Assert.AreEqual(true, fakeGo.activeInHierarchy, "Gameobject is active");
        }
    }
}
