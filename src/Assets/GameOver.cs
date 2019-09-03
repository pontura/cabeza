using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject panel;
    public Text scoreField;

    void Start()
    {
        Reset();
    }
    public void Reset()
    {
        panel.SetActive(false);
    }
    public void Init()
    {
        panel.SetActive(true);
        scoreField.text = Utils.FormatNumbers(UI.Instance.uiScoreManager.score);
        Invoke("Restart", 2);
    }
    void Restart()
    {
        Events.OnInitGame(GameData.types.VOMIT);
    }
}
