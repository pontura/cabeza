using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    
    public void Init()
    {
        transform.localScale = Vector3.one;
        transform.localEulerAngles = Vector3.zero;
        transform.localPosition = Vector3.zero;
        rb.velocity = Vector3.zero;
        OnInit();         
    }
    
    public virtual void OnInit() { }
    public virtual void UpdateByController() { }
}
