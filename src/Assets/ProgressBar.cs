using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject panel;
    public Image bar;
    public float value;
    public float speed = 10;
    bool isOn;

    void Start()
    {
        panel.SetActive(false);
    }
    public void Reset()
    {
        isOn = false;
        CancelInvoke();
    }
    public void Init(GameData.types type)
    {
        
    }
    public void OnStartGame()
    {
        panel.SetActive(true);
        isOn = true;
        value = 1;
        Loop();
    }
    void Loop()
    {
        if (!isOn)
            return;
        value -= 0.01f;
        Invoke("Loop", 1);
        SetState();
    }
    public void OnProgressAdd(float qty)
    {
        value += qty;
        if (value > 1)
            value = 1;
        SetState();
    }
    void SetState()
    {
        if (value < 0)
        {
            value = 0;
            Events.OnProgressBarDone();
            isOn = false;
        }
        bar.fillAmount = value;
    }
}
