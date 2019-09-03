using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GamesManager : MonoBehaviour
{
    public GameData.types startingGameType;

    [Serializable]
    public class GamesData
    {
        public GameData gameData;
        public Game game;
    }
    public InteractiveItemsManager itemsManager;
    public FaceBasicDetections faceBasicDetections;
    public EnemiesManager enemiesManager;

    public List<GamesData> games;
    public Game game;

    public states state;
    public enum states
    {
        HEAD_OFF,
        HEAD_ON        
    }

    void Awake()
    {
        Events.OnInitGame += OnInitGame;
        Events.GameOver += GameOver;
        Events.OnUserStatus += OnUserStatus;
    }
    void Start()
    {
        foreach (GamesData gData in games)
            gData.game.gameObject.SetActive(false);
        Events.OnInitGame(startingGameType);
    }
    void OnUserStatus(bool isOn)
    {
        if (isOn)
            state = states.HEAD_ON;
        else
            state = states.HEAD_OFF;

        game.OnUserStatus(isOn);
    }
    void OnInitGame(GameData.types type)
    {
        game = GetGameByType(type);
        game.gameObject.SetActive(true);
        game.Init(this);        
        faceBasicDetections.Init();
        if (state == states.HEAD_ON)
            game.OnUserStatus(true);
    }
    void GameOver()
    {
        game.Reset();        
        faceBasicDetections.Reset();
        enemiesManager.Reset();
        itemsManager.Reset();
    }
    Game GetGameByType(GameData.types type)
    {
        foreach (GamesData gData in games)
        {
            if (gData.gameData.type == type)
                return gData.game;
        }
        return null;
    }

}
