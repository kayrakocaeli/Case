using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] PoolObj[] Objs;
    Dictionary<string, Pool> Pools;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        InitializePools();
    }
    void InitializePools()
    {
        Pools = new Dictionary<string, Pool>();
        foreach (var obj in Objs)
        {
            var parent = new GameObject(obj.Obj.name + " pool");
            parent.transform.SetParent(transform);

            Pools.Add(obj.Obj.name, new Pool(obj.Obj, obj.CountToSpawn, parent.transform));
        }
    }
    public GameObject Instantiate(GameObject obj)
    {
        
        return Pools[obj.name].Instantiate();
    }
    public void Destroy(GameObject obj)
    {
        Pools[obj.name].Destroy(obj);
    }
    public void Destroy(GameObject obj, float time)
    {
        StartCoroutine(DestroyWithDelay(obj, time));
    }

    IEnumerator DestroyWithDelay(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        instance.Destroy(obj);
    }
}

[System.Serializable]
public class PoolObj
{
    public GameObject Obj;
    public int CountToSpawn;
}

public class Pool
{
    public static List<GameObject> ActiveObjs;
    readonly List<GameObject> InactiveObjs;
    readonly Transform Parent;
    public Pool(GameObject obj, int count, Transform parent)
    {
        Parent = parent;
        ActiveObjs = new List<GameObject>();
        InactiveObjs = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            var clone = Object.Instantiate(obj);
            clone.name = obj.name;
            clone.SetActive(false);
            clone.transform.SetParent(parent);
            InactiveObjs.Add(clone);
        }
    }
    public GameObject Instantiate()
    {
        if (InactiveObjs.Count == 0)
            return null;
        var obj = InactiveObjs[0];
        obj.SetActive(true);
        InactiveObjs.RemoveAt(0);
        ActiveObjs.Add(obj);
        return obj;
    }

    public void Destroy(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(Parent);
        ActiveObjs.Remove(obj);
        InactiveObjs.Add(obj);
    }
}