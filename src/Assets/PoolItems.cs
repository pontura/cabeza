using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolItems : MonoBehaviour
{
    public List<InteractiveItemsData> all;

    public List<InteractiveItem> pooled;

    public Transform pooledObjects;

    [Serializable]
    public class InteractiveItemsData
    {
        public InteractiveItem interactiveItem;
        public int qty;
    }
    
    void Start()
    {
        AddItems();
        Events.Pool += Pool;
    }
    void AddItems()
    {
        foreach (InteractiveItemsData d in all)
        {
            for (int a = 0; a < d.qty; a++)
            {
                InteractiveItem newItem = Instantiate(d.interactiveItem);                
                Pool(newItem);
            }
        }
    }
    public InteractiveItem GetItem(string name)
    {
        if (pooled.Count > 0)
        {
            InteractiveItem i = pooled[0];
            pooled.Remove(i);
            i.gameObject.SetActive(true);
            return i;
        }
        else
            return null;
    }
    void Pool(InteractiveItem item)
    {
        item.transform.SetParent(pooledObjects);
        item.gameObject.SetActive(false);
        pooled.Add(item);
    }
}
