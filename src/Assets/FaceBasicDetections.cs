﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Runtime.InteropServices;
using System.Text;

public class FaceBasicDetections : MonoBehaviour
{
    public FacetrackingManager faceTrackingManager;
    public Transform container;
    public VertexPointCustom vertex_to_instantiate;
    public List<VertexPointCustom> allFaceVertex;

    public mouthStates mouthState;

    private float mouthSmoothFilter = 0.1f;
    private float smoothMouthValue = 0;    

    public enum mouthStates
    {
        CLOSE,
        OPEN
    }
    public GameObject faceInteractions;
    public Vector3 headRotation;

    bool ready;
    void Update()
    {
        headRotation = faceTrackingManager.GetHeadRotation(true).eulerAngles;
        faceInteractions.transform.localEulerAngles = headRotation;
        //el 22 es la punta de arriba de la boca:
        Vector3 vert_pos_mouth_1 = faceTrackingManager.GetFaceModelVertex(22);
        //el 10 es la punta de abajo de la boca:
        Vector3 vert_pos_mouth_2 = faceTrackingManager.GetFaceModelVertex(10);

        float mouthValue = Vector3.Distance(vert_pos_mouth_1, vert_pos_mouth_2);
        smoothMouthValue = Mathf.Lerp(mouthValue, smoothMouthValue, mouthSmoothFilter);

        SetMouthState();

       // DrawPoints();

    }
    void SetMouthState()
    {
        if(smoothMouthValue<0.03f && mouthState != mouthStates.CLOSE)
        {
            mouthState = mouthStates.CLOSE;
            Events.OnMouthOpen(mouthState);
        } else if (smoothMouthValue > 0.03f && mouthState != mouthStates.OPEN)
        {
            mouthState = mouthStates.OPEN;
            Events.OnMouthOpen(mouthState);
        }
    }
    void DrawPoints()
    {
        int id = 0;
        foreach (VertexPointCustom v in allFaceVertex)
        {
            Vector3 vert_pos = faceTrackingManager.GetFaceModelVertex(id);
            v.transform.position = vert_pos;
            id++;
            // print(Vector3.Distance(pos, pos2));
        }

        if (ready) return;

        Dictionary<KinectInterop.FaceShapeDeformations, float> all = faceTrackingManager.dictSU;

        id = 0;
        foreach (KinectInterop.FaceShapeDeformations a in all.Keys)
        {
            print(id + " :         " + a);
            VertexPointCustom v = Instantiate(vertex_to_instantiate);
            v.transform.SetParent(container);
            allFaceVertex.Add(v);

            if (id == 22)
                v.Init(Color.green, id);
            else if (id == 10)
                v.Init(Color.red, id);
            else
                v.Init(Color.white, id);

            id++;
        }
        if (all.Count > 10)
            ready = true;
    }

}
