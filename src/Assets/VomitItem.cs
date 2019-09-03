using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitItem : InteractiveItem
{
    public override void OnInit()
    {
      //  rb.AddForce(transform.up * 100);
        rb.AddForce(transform.forward * -1 * speed);
    }
    public void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponentInParent<Enemy>();
        if (enemy == null)
            return;
        enemy.Killed();
    }
}
