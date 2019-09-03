using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Data : MonoBehaviour
{
    const string PREFAB_PATH = "Data";    
    static Data mInstance = null;
    public Animator fade;
    public string levelName;
    public KinectManager kinect;
    public Image cursorHand;
    public PoolItems pool;

    public static Data Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Data>();

                if (mInstance == null)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
                    mInstance = go.GetComponent<Data>();
                }
            }
            return mInstance;
        }
    }
    public string currentLevel;
   
    void Awake()
    {
		Cursor.visible = false;

        if (!mInstance)
            mInstance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }       
        DontDestroyOnLoad(this.gameObject);
        pool = GetComponent<PoolItems>();
       // Events.UseKinect += UseKinect;
       //  UseKinect(false);
    }
    bool loading;
    public void LoadLevel(string _levelName)
    {
        if (loading)
            return;

        levelName = _levelName;

        StartCoroutine(LoadLevelRoutine(levelName));
    }
    IEnumerator LoadLevelRoutine(string levelName)
    {
        loading = true;
        fade.gameObject.SetActive(true);
        fade.Play("fadeIn");
        yield return new WaitForSeconds(0.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
        yield return new WaitForSeconds(0.1f);
        fade.Play("fadeOut");
        yield return new WaitForSeconds(0.6f);
        fade.gameObject.SetActive(false);
        loading = false;
    }
    void UseKinect(bool isOn)
    {
        print(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + " ison: " + isOn);
        kinect.gameObject.SetActive(isOn);
       // kinect.SetState(isOn);
        cursorHand.enabled = isOn;
    }
}
