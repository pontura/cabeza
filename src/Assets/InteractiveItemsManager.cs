using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItemsManager : MonoBehaviour
{
    public List<InteractiveItem> all;
    float delay;
    int _Y = -17;

    void Start()
    {
        Events.Pool += Pool;
    }
    void OnDestroy()
    {
        Events.Pool -= Pool;
    }
    public void Init(float delay)
    {
        this.delay = delay;
        LoopCheck();
    }
    public void Add(InteractiveItem item)
    {
        all.Add(item);
        item.Init();
    }
    void LoopCheck()
    {        
        Invoke("LoopCheck", delay);
        UpdateItems();
    }
    void UpdateItems()
    {
        List<InteractiveItem> itemsToPool = new List<InteractiveItem>();
        foreach (InteractiveItem item in all)
        {
            if (item.transform.localPosition.z < -5 || item.transform.localPosition.y < _Y)
            {
                itemsToPool.Add(item);
            }
            else
                item.UpdateByController();
        }
        foreach(InteractiveItem itemToPool in itemsToPool)
            Events.Pool(itemToPool);
    }
    void Pool(InteractiveItem item)
    {
        all.Remove(item);
    }
    public void Reset()
    {
        CancelInvoke();
        List<InteractiveItem> itemsToPool = new List<InteractiveItem>();

        foreach (InteractiveItem item in all)
            itemsToPool.Add(item);

        foreach (InteractiveItem itemToPool in itemsToPool)
            Events.Pool(itemToPool);
    }
}
