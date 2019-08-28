using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Settings : MonoBehaviour
{
    public SettingsData settingsData;

    [Serializable]
    public class SettingsData
    {
        public float hand_distances;
        public float swimmerSpeed;
        public float walkerSpeed;
        public float desaceleration;
        public int triviaTime;
        public int swimTime;
    }
    void Start()
    {
       // StartCoroutine(Load() );
    }
    public IEnumerator Load()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "settings.json");
        string dataAsJson;
        print(filePath);
        if (filePath.Contains("://"))
        {
            WWW www = new WWW(filePath);
            yield return www;
            dataAsJson = www.text;
        }
        else
        {
            dataAsJson = File.ReadAllText(filePath);
        }
        settingsData = JsonUtility.FromJson<SettingsData>(dataAsJson);
        print(dataAsJson);
        Events.OnSettingsDone();
    }
}
