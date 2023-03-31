using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class ObjectPooler : Singleton<ObjectPooler>
    {
        [System.Serializable]
        public class Pool
        {
            public PoolObjectTag Tag;
            public GameObject Prefab;
            public int Size;
        }

        public List<Pool> _pools;
        public Dictionary<PoolObjectTag, Queue<GameObject>> _poolDictionary;

        private void Awake()
        {
            _poolDictionary = new Dictionary<PoolObjectTag, Queue<GameObject>>();

            foreach (Pool pool in _pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.Size; i++)
                {
                    GameObject obj = Instantiate(pool.Prefab, transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                _poolDictionary.Add(pool.Tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(PoolObjectTag tag, Vector3 position, Quaternion rotation)
        {
            if (_poolDictionary.ContainsKey(tag) == false)
                return null;

            GameObject objectToSpawn = _poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

            if (pooledObject != null)
            {
                pooledObject.OnObjectSpawn();
            }

            _poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}

public enum PoolObjectTag : int
{
    BulletDefault,

    EnemyDefault,
    Player,
}