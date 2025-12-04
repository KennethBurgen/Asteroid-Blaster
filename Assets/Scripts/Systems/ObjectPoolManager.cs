using UnityEngine;

namespace Systems
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance { get; private set; }

        #region Singleton

        /// <summary>
        /// Stellt sicher, dass der InputProvider nur einmal existiert - Singleton
        /// </summary>
        private void InitializeSingleton()
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
        }
    }
}
