using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreManager : MonoBehaviour
{
    public GameObject panel;
    public Text field;
    public int score;

    void Start()
    {        
        Events.OnAddScore += OnAddScore;
        panel.SetActive(false);
    }
    public void Init(GameData.types type)
    {        
        
    }
    public void OnStartGame()
    {
        panel.SetActive(true);
        score = 0;
        SetField();
    }
    public void OnAddScore(int qty)
    {
        score += qty;
        SetField();
    }
    void SetField()
    {
        field.text = Utils.FormatNumbers(score);
    }
}
