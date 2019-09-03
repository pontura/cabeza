using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaUI : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(true);
        Events.OnUserStatus += OnUserStatus;
    }
    void OnUserStatus(bool isOn)
    {
        panel.SetActive(!isOn);
    }
}
