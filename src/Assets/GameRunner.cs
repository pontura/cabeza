using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : Game
{
    public FaceBasicDetections faceBasicDetections;
    public Road road;

    public override void OnStart()
    {
        road.Init(this);
    }
    public override void CheckIfAddEnemy(Transform container )
    {
        print("CheckIfAddEnemy");
        gamesManager.enemiesManager.AddEnemyToContainer("Cat", container, new Vector3(Random.Range(-5,5),0,0));
    }
    private void Update()
    {       
        Vector3 pos = road.transform.localPosition;
        pos.x = Mathf.Lerp(pos.x, faceBasicDetections.GetZRotation(), 0.01f);
        road.transform.localPosition = pos;
    }
}
