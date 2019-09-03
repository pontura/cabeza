using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCustomController : MonoBehaviour
{
    public float randomTime;

    private void Start()
    {
        Animation anim = GetComponent<Animation>();
        string clipName = anim.clip.name;
        anim[clipName].time = Random.Range(0, 10)/10;
        anim.Play();
    }
}
