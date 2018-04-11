using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneStart : SceneStart
{
    void Start()
    {
        LoadingControl t = UIControlStackManager.I.Push<LoadingControl>();
        t.Show();
    }

    public override void StartScence()
    {
        LoadingControl t = UIControlStackManager.I.Push<LoadingControl>();
        t.Show();
    }

}
