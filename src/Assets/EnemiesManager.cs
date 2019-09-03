using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public Transform container;
    float delay;
    public InteractiveItemsManager itemsManager;
    string itemName;

    private void Start()
    {
        Events.OnUserStatus += OnUserStatus;
    }
    void OnUserStatus(bool isOn)
    {
        CancelInvoke();
        if (isOn)
        {           
            //Loop();
        }
    }
    public void InitLoop(string itemName, float delay)
    {
        this.itemName = itemName;
        this.delay = delay;
        Loop();
    }
    void Loop()
    {
        Invoke("Loop", delay);
        AddEnemy();
    }
    void AddEnemy()
    {
        InteractiveItem item = Data.Instance.pool.GetItem(itemName);
        item.transform.SetParent(container);
        itemsManager.Add(item);
    }
    public void AddEnemyToContainer(string _itemName, Transform _container, Vector3 pos)
    {
        InteractiveItem item = Data.Instance.pool.GetItem(_itemName);
        item.transform.SetParent(_container);
        item.transform.localPosition = pos;
        itemsManager.Add(item);
    }
    public void Reset()
    {
        CancelInvoke();
    }
}
