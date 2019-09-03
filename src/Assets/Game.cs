using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [HideInInspector]
    public GamesManager gamesManager;

    public states state;
    public enum states
    {
        IDLE,
        PLAYING,
        GAMEOVER
    }
    public void Init(GamesManager gamesManager)
    {
        this.gamesManager = gamesManager;
        Events.OnKillEnemy += OnKillEnemy;
        Events.OnProgressBarDone += OnProgressBarDone;
        Events.OnMouthOpen += OnMouthOpen;
    }
    public void Reset()  {
        Events.OnKillEnemy -= OnKillEnemy;
        Events.OnProgressBarDone -= OnProgressBarDone;
        Events.OnMouthOpen -= OnMouthOpen;
        OnReset();
    }
    public void OnUserStatus(bool isOn)
    {
        if (state == states.PLAYING)
            return;
        if (isOn)
            Init();
    }
    void Init()
    {
        state = states.PLAYING;
        Events.OnStartGame();
        OnStart();
        gamesManager.itemsManager.Init(0.1f);
    }    
    public InteractiveItem AddItem(string itemName)
    {
        InteractiveItem item = Data.Instance.pool.GetItem(itemName);
        if (item == null)
            return null;
        gamesManager.itemsManager.Add(item);
        return item;
    }
    public void InitEnemies(string itemName, float delay)
    {
        gamesManager.enemiesManager.InitLoop(itemName, delay);
    }
    void OnProgressBarDone()
    {
        Events.GameOver();
        state = states.GAMEOVER;
    }
    public virtual void CheckIfAddEnemy( Transform container ) { }
    public virtual void OnKillEnemy(Enemy enemy) { }
    public virtual void OnStart() { }
    public virtual void OnReset() { }
    public virtual void OnMouthOpen(FaceBasicDetections.mouthStates mouthStates) { }
}
