using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneStart : SceneStart
{
    public void Start()
    {
        UIControlStackManager.I.Pop();
        MainUIControl t = UIControlStackManager.I.Push<MainUIControl>();
        t.Show();
    }

    public override void StartScence()
    {
        UIControlStackManager.I.Pop();
        MainUIControl t = UIControlStackManager.I.Push<MainUIControl>();
        t.Show();
    }
}
