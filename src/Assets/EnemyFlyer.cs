using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyer : Enemy
{
    float speed = 0.15f;
    public Vector2 fromTo;
    bool rightToLeft;
    public override void OnInit()
    {
        if (Random.Range(0, 10) > 5)
            rightToLeft = true;
        else
            rightToLeft = false;

        float startX = fromTo.x;

        if (rightToLeft)
            startX = fromTo.y;

        startX *= 1 + Random.Range(1, 10) / 10;

        transform.localPosition = new Vector3(startX, (float)Random.Range(-10,10)/100, -0.2f);
    }
    private void Update()
    {
        Vector3 pos = transform.localPosition;

        if (rightToLeft)
            pos.x -= Time.deltaTime * speed;
        else
            pos.x += Time.deltaTime * speed;

        transform.localPosition = pos;
        if (!rightToLeft && pos.x > fromTo.y)
            Pool();
        else if (rightToLeft && pos.x < fromTo.x)
            Pool();
    }
    void Pool()
    {
        Events.Pool(this);
    }
}
