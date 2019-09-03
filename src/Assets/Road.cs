using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPart;
    public List<GameObject> allParts;
    int parts = 10;
    int separation = 5;
    float newPos;
    public float speed = 6f;
    Game game;

    public void Init(Game game)
    {
        this.game = game;
        for (int a = 0; a < parts; a++)
        {
            GameObject part = Instantiate(roadPart);
            part.transform.SetParent(transform);
            part.transform.localScale = Vector3.one;
            part.transform.localEulerAngles = Vector3.zero;
            part.transform.localPosition = new Vector3(0, 0, ((separation * parts) / 2) - a * separation);
            allParts.Add(part);
        }
        Loop();
    }
    
    void Update()
    {
        foreach (GameObject part in allParts)
        {
            Vector3 pos = part.transform.localPosition;
            pos.z += Time.deltaTime * speed;
            part.transform.localPosition = pos;
        }
    }
    void Loop()
    {
        foreach(GameObject part in allParts)
        {
            if (part.transform.localPosition.z > separation * parts / 2)
                RestartPartPosition(part);
        }
        Invoke("Loop", 0.1f);
    }
    void RestartPartPosition(GameObject part)
    {
        part.transform.localPosition = new Vector3(0, 0, -(separation * parts) / 2);
        game.CheckIfAddEnemy(part.transform);
    }
}
