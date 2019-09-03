using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

    public static System.Action<bool> OnUserStatus = delegate { };
    public static System.Action<bool> UseKinect= delegate { };

    public static System.Action<GameData.types> OnInitGame = delegate { };
    public static System.Action OnStartGame = delegate { };
    public static System.Action GameOver = delegate { };

    public static System.Action<FaceBasicDetections.mouthStates> OnMouthOpen = delegate { };
    public static System.Action<InteractiveItem> Pool = delegate { };
    public static System.Action<Vector3> OnAddExplotion = delegate { };    

    public static System.Action<float> OnProgressAdd = delegate { };
    public static System.Action OnProgressBarDone = delegate { };
    
    public static System.Action<int> OnAddScore = delegate { };
    public static System.Action<Enemy> OnKillEnemy = delegate { };

}

