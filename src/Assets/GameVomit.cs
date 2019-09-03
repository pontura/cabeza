using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVomit : Game
{
    public Transform mouthContainer;
    public Transform container;
    public GameObject vomitPiece;
    FaceBasicDetections.mouthStates mouthStates;
   
    float delay = 0.035f;

    public override void OnStart()
    {        
        Loop();
        Invoke("InitEnemiesDelayed", 1);
    }
    public override void OnReset()
    {
        CancelInvoke();
    }
    public override void OnKillEnemy(Enemy enemy)
    {
        Events.OnProgressAdd(0.025f);
        Events.OnAddScore(150);
    }
    void InitEnemiesDelayed()
    {
        InitEnemies("FlyerItem", 0.5f);
    }
    public override void OnMouthOpen(FaceBasicDetections.mouthStates mouthStates)
    {
        this.mouthStates = mouthStates;
    }
    void Loop()
    {
        Invoke("Loop", delay);
        if (mouthStates == FaceBasicDetections.mouthStates.OPEN)
        {
            Vomit();
        }
    }
    void Vomit()
    {
        Events.OnProgressAdd(-0.002f);
        InteractiveItem item = AddItem("VomitItem");
        if (item == null) return;
        item.transform.SetParent(mouthContainer);
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
        item.transform.SetParent(container);
    }
    
}
