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
                newItem.name = d.interactiveItem.name;
            }
        }
    }
    public InteractiveItem GetItem(string name)
    {        
        foreach (InteractiveItem item in pooled)
        {
            if (item.name == name)
            { 
                pooled.Remove(item);
                item.gameObject.SetActive(true);
                return item;
            }
        }
        print("<POOL> no existe : " + name);
        return null;
    }
    void Pool(InteractiveItem item)
    {
        item.transform.SetParent(pooledObjects);
        item.gameObject.SetActive(false);
        pooled.Add(item);
    }
}
