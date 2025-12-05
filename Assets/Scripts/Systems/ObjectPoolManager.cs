using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Tests.EditMode.Systems")]

namespace Systems
{
    /// <summary>
    /// Verwendet um Objekte mit hoher Anzahl an Erzeugungs- und Zerstörungsvorgängen zu instanzieren und zu verwalten
    /// </summary>
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance { get; private set; }

        internal static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();
        public static IReadOnlyList<PooledObjectInfo> ObjectPoolsReadOnly =>
            ObjectPools.AsReadOnly();

        // Hierarchie organisation
        private GameObject _objectPoolEmptyHolder;
        internal static GameObject _gameObjectsEmpty;
        internal string _prefabSubfix;

        public enum PoolType
        {
            Gameobject,
            None,
        }

        #region Singleton

        /// <summary>
        /// Stellt sicher, dass der ObjectPoolManager nur einmal existiert - Singleton
        /// </summary>
        internal void InitializeSingleton()
        {
            if (Instance is not null && Instance != this)
            {
                Debug.LogWarning(
                    "Deleting Component - ObjectPoolManager - on Gameobject - "
                        + gameObject.name
                        + " - because ObjectPoolManager already exists."
                );
                Destroy(this);
                return;
            }

            Instance = this;
        }

        #endregion

        void Awake()
        {
            InitializeSingleton();
            SetupEmpties();
        }

        #region Organisation

        /// <summary>
        /// Erstellt die Parent-Gameobjects zur Organisation der gepoolten Objekte
        /// </summary>
        internal void SetupEmpties()
        {
            _objectPoolEmptyHolder = new GameObject("Pooled Objects");

            _gameObjectsEmpty = new GameObject("GameObjects");
            _gameObjectsEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);
        }

        /// <summary>
        /// Sucht das organisatorische Parent-Gameobject passend zum <see cref="PoolType"/>
        /// </summary>
        /// <param name="poolType">der <see cref="PoolType"/></param>
        /// <returns></returns>
        internal GameObject GetParentObject(PoolType poolType)
        {
            return poolType switch
            {
                PoolType.Gameobject => _gameObjectsEmpty,
                PoolType.None => null,
                _ => null,
            };
        }

        /// <summary>
        /// Sucht den <see cref="PooledObjectInfo">ObjectPool</see>, falls keiner vorhanden ist, wird einer erstellt
        /// </summary>
        /// <param name="objectName">der Name des Objekts als <see cref="string"/></param>
        /// <returns><see cref="PooledObjectInfo"/></returns>
        internal PooledObjectInfo FindOrCreateObjectPool(string objectName)
        {
            PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectName);

            // Wenn der Pool nicht existiert wird er erstellt
            if (pool == null)
            {
                pool = new PooledObjectInfo() { LookupString = objectName };
                ObjectPools.Add(pool);
            }

            return pool;
        }

        #endregion

        #region Spawning und Deactivating

        /// <summary>
        /// Spawnt ein <see cref="GameObject"/>, weißt es dem zugehörigen ObjectPool hinzu und ordnet es in der Hierarchie
        /// </summary>
        /// <param name="objectToSpawn">das <see cref="GameObject"/> das gespawnt werden soll</param>
        /// <param name="spawnPosition">die <see cref="Vector3">Position</see> an dem das Objekt gespawnt werden soll</param>
        /// <param name="spawnRotation">die <see cref="Quaternion">Rotation</see> mit der das Objekt gespawnt werden soll</param>
        /// <param name="poolType">der <see cref="PoolType"/> für die organisatorische Zuweisung des Parent-Gameobjects</param>
        /// <returns></returns>
        public GameObject SpawnObject(
            GameObject objectToSpawn,
            Vector3 spawnPosition,
            Quaternion spawnRotation,
            PoolType poolType = PoolType.None
        )
        {
            if (!objectToSpawn)
            {
                Debug.LogError("Cannot spawn a null object");
                return null;
            }

            PooledObjectInfo pool = FindOrCreateObjectPool(objectToSpawn.name);

            // Prüfen ob es inactive Objekte in diesem Pool gibt
            GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();

            if (!spawnableObj)
            {
                // Suche das organisatorische Parent-Gameobject zum übergebenen GameObject
                GameObject parentObject = GetParentObject(poolType);

                // Wenn es keine inaktiven Gameobjects gibt wird eines erstellt
                spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);

                // lese den prefabSubfix der bei Instantiate eines Prefabs entsteht
                _prefabSubfix = spawnableObj.name.Replace(objectToSpawn.name, "").Trim();

                // Wenn es ein organisatiorisches Parent-Gameobject gibt, weise es zu
                if (parentObject)
                {
                    spawnableObj.transform.SetParent(parentObject.transform);
                }
            }
            else
            {
                // Wenn es ein inaktives Gameobject gibt wird es reaktiviert
                spawnableObj.transform.position = spawnPosition;
                spawnableObj.transform.rotation = spawnRotation;
                pool.InactiveObjects.Remove(spawnableObj);
                spawnableObj.SetActive(true);
            }

            return spawnableObj;
        }

        /// <summary>
        /// Deaktiviert das Gameobject und ordnet es anhand seines Namens den inactiven Objekten des zugehörigen <see cref="PooledObjectInfo"> Objektpools</see> zu
        /// </summary>
        /// <param name="obj">das <see cref="GameObject"/></param>
        public void ReturnObjectToPool(GameObject obj)
        {
            if (!obj)
            {
                Debug.LogWarning("Trying to release a null object");
                return;
            }

            // Substring - (Clone) - eines per Instantiate erstellten Objects rausfiltern
            string goName = obj.name;
            if (!string.IsNullOrEmpty(_prefabSubfix) && goName.EndsWith(_prefabSubfix))
            {
                goName = goName.Replace(_prefabSubfix, "");
            }
            else if (string.IsNullOrEmpty(_prefabSubfix))
            {
                Debug.LogWarning("No prefab subfix");
            }

            PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == goName);

            if (pool == null)
            {
                Debug.LogWarning("Trying to release an object that is not pooled: " + obj.name);
            }
            else
            {
                obj.SetActive(false);
                if (!pool.InactiveObjects.Contains(obj))
                {
                    pool.InactiveObjects.Add(obj);
                }
            }
        }

        /// <summary>
        /// Deaktiviert alle Gameobjects die der <see cref="ObjectPoolManager"/> verwaltet
        /// </summary>
        public void DeactivateAllObjects()
        {
            foreach (Transform transformComp in _gameObjectsEmpty.transform)
            {
                ReturnObjectToPool(transformComp.gameObject);
            }
        }

        #endregion

#if UNITY_INCLUDE_TESTS
        /// <summary>
        /// Um im Test die Singleton-Instanz des <see cref="ObjectPoolManager"/> zu löschen und die ObjectPools zu leeren
        /// </summary>
        internal static void ResetSingletonForTests()
        {
            Instance = null;
            ObjectPools.Clear();
            _gameObjectsEmpty = null;
        }
#endif
    }

    public class PooledObjectInfo
    {
        public string LookupString;
        public List<GameObject> InactiveObjects = new List<GameObject>();
    }
}
