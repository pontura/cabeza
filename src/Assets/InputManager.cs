using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool isClicking;
    float delayed = 0.1f;
    float timer;
    

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Data.Instance.levelName == "VideoPlayer")
            {
                Data.Instance.LoadLevel("GameSelector");
                Events.UseKinect(true);
            }
            else
            {
                Data.Instance.LoadLevel("VideoPlayer");
                Events.UseKinect(false);
            }
        }
       
        if (InteractionManager.Instance == null)
            return;

        InteractionManager.HandEventType rightHand = InteractionManager.Instance.GetRightHandEvent();
        InteractionManager.HandEventType leftHand = InteractionManager.Instance.GetLeftHandEvent();

        if (rightHand == InteractionManager.HandEventType.Grip)// || leftHand == InteractionManager.HandEventType.Grip)
        {
            if (isClicking)
                return;
            timer += Time.deltaTime;
            if (timer > delayed)
            {
                Events.OnClick();
                isClicking = true;
            }
        }
        else
        {
            if(isClicking)
            {
                Events.OnReleaseHand();
            }
            timer = 0;
            isClicking = false;
        }

    }
}
