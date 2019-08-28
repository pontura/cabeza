using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

    public static System.Action<int> QuestionDone = delegate { };
	public static System.Action<bool> OnUserStatus = delegate { };
    public static System.Action OnClick = delegate { };
    public static System.Action OnReleaseHand = delegate { };
    public static System.Action OnSettingsDone = delegate { };
    public static System.Action OnTimeOut = delegate { };
    public static System.Action<string> OnUIFX = delegate { };
    public static System.Action StartTrivia = delegate { };
    public static System.Action StartSwiming = delegate { };
    public static System.Action EndTrivia = delegate { };
    public static System.Action<bool, float> SetChronometer = delegate { };
    public static System.Action<int> OnScore = delegate { };
    public static System.Action<bool> ShowCursor = delegate { };
    public static System.Action OnReset = delegate { };
    public static System.Action<bool> UseKinect= delegate { };
    public static System.Action<FaceBasicDetections.mouthStates> OnMouthOpen = delegate { };
    public static System.Action<InteractiveItem> Pool = delegate { };
}

