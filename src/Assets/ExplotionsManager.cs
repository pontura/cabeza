using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionsManager : MonoBehaviour
{
    public GameObject explotion;
    GameObject explotionGO;

    void Start()
    {
        Events.OnAddExplotion += OnAddExplotion;
    }
    void OnAddExplotion(Vector3 pos)
    {
        explotionGO = Instantiate(explotion) as GameObject;
        explotionGO.transform.localPosition = pos;
        Invoke("Reset", 5);
    }
    void Reset()
    {
        Destroy(explotionGO);
    }
}
