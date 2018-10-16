using System.Collections.Generic;
using UnityEngine;

public class PoolControl : Singleton<PoolControl>
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    //Makes this reset with the room
    public override void Awake() { }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        //if (!poolDictionary.ContainsKey(tag))
        //{
        //    Debug.LogWarning(tag + " Not in Pools list!");
        //    return null;
        //}

        GameObject obj = poolDictionary[tag].Dequeue();

        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        IpooledObject objPooled = obj.GetComponent<IpooledObject>();
        if (objPooled != null) { objPooled.OnObjectSpawn(); }

        poolDictionary[tag].Enqueue(obj);

        return obj;

    }
}
