using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexPointCustom : MonoBehaviour
{
    public int id;
    public void Init(Color color, int id)
    {
        this.id = id;
        GetComponent<MeshRenderer>().material.color = color;
    }
}
