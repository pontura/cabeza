using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVomit : MonoBehaviour
{
    public Transform container;
    public GameObject vomitPiece;
    FaceBasicDetections.mouthStates mouthStates;
    float delay = 0.1f;
    float timer;

    void Start()
    {
        Events.OnMouthOpen += OnMouthOpen;
    }
    
    void OnMouthOpen(FaceBasicDetections.mouthStates mouthStates)
    {
        this.mouthStates = mouthStates;
    }
    private void Update()
    {
        if (mouthStates == FaceBasicDetections.mouthStates.OPEN)
        { 
            timer += Time.deltaTime;
            if (timer > delay)
            {
                Vomit();
                timer = 0;
            }
        }
    }
    void Vomit()
    {
        InteractiveItem item = Data.Instance.pool.GetItem("____");
        item.transform.SetParent(container);
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;

    }
}
