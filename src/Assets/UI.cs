using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI mInstance;
    public UIScoreManager uiScoreManager;
    public GameOver gameOver;
    public ProgressBar progressBar;

    public static UI Instance
    {
        get
        {
            return mInstance;
        }
    }
    void Awake()
    {
        mInstance = this;
        Events.GameOver += GameOver;
        Events.OnInitGame += OnInitGame;
        Events.OnProgressAdd += OnProgressAdd;
        Events.OnStartGame += OnStartGame;
    }
    void GameOver()
    {
        gameOver.Init();
        progressBar.Reset();
    }
    void OnInitGame(GameData.types type)
    {
        print("OnInitGame " + type);
        progressBar.Init(type);
        uiScoreManager.Init(type);
        gameOver.Reset();
    }
    void OnStartGame()
    {
        print("OnStartGame");
        progressBar.OnStartGame();
        uiScoreManager.OnStartGame();
    }
    void OnProgressAdd(float qty)
    {
        progressBar.OnProgressAdd(qty);
    }

}
