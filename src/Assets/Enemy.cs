using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : InteractiveItem
{
    public Vector3 exploptionOffset = new Vector3(-2f, -2f, 0);
    public void Killed()
    {
        Events.OnKillEnemy(this);
        Events.OnAddExplotion(transform.position + exploptionOffset);
        Events.Pool(this);
    }
}
