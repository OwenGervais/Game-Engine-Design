using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPooler 
{
    public static Dictionary<string, Component> poolLookup = new Dictionary<string, Component>();
    public static Dictionary<string, Queue<Component>> poolDictionary = new Dictionary<string, Queue<Component>>();

    public static void EnqueueObject<T>(T item, string name) where T : Component
    {
        if (!item.gameObject.activeSelf) { return; }

        item.transform.position = Vector2.zero;
        poolDictionary[name].Enqueue(item);
        item.gameObject.SetActive(false);
    }

    public static T DequeueObject<T>(string key) where T : Component
    {
        if(poolDictionary[key].TryDequeue(out var item))
        {
            return (T)item;
        }

        return (T)EnqueueNewInstance(poolLookup[key], key);
    }

    public static T EnqueueNewInstance<T>(T item, string key) where T : Component
    {
        //if (poolDictionary[key].Count < 500)
        //{
            T newInstance = Object.Instantiate(item);
            newInstance.gameObject.SetActive(false);
            newInstance.transform.position = Vector2.zero;
            poolDictionary[key].Enqueue(newInstance);
            return newInstance;
        //}
        //return null;

    }

    public static void SetupPool<T>(T pooledItemPrefab, int poolSize, string dictonaryEntry) where T : Component
    {
        poolDictionary.Add(dictonaryEntry, new Queue<Component>());

        poolLookup.Add(dictonaryEntry, pooledItemPrefab);

        for (int i = 0; i < poolSize; i++)
        {
            T poolInstance = GameObject.Instantiate(pooledItemPrefab);
            poolInstance.gameObject.SetActive(false);
            poolDictionary[dictonaryEntry].Enqueue((T)poolInstance);
        }
    }
}