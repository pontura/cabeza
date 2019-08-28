using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * -1 * speed/2);
        rb.AddForce(transform.forward * -1 * speed);
    }
}
