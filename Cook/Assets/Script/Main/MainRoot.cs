using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainRoot : MonoBehaviour
{
    public GameObject LeftObj;
    public GameObject RightObj;
    bool isTurnLeft;
    bool isTurnRight;

    void Awake()
    {
        EventManager.I.AddEvent(MainUIModel.Main_LeftOn, OnLeftBar);
        EventManager.I.AddEvent(MainUIModel.Main_RightOn, OnRightBar);
    }

    public void OnLeftBar(MessageData data)
    {
        RotateTarget(LeftObj,BarE.LEFT);
    }

    public void OnRightBar(MessageData data)
    {
        RotateTarget(RightObj,BarE.RIGHT);
    }

    public void RotateTarget(GameObject target, BarE e)
    {
        if( e == BarE.LEFT)
        {
            if (isTurnLeft)
                return;
            isTurnLeft = true; 
        }
        else if(e == BarE.RIGHT)
        {
            if (isTurnRight)
                return;
            isTurnRight = true;
        }
        Transform trans = target.transform;
        Tween tween = trans.DORotate(new Vector3(0, 0, 90), 0.2f, RotateMode.LocalAxisAdd);
        tween.onComplete = () =>
        {
            Tween t = trans.DORotate(new Vector3(0, 0, -90), 0.2f, RotateMode.LocalAxisAdd);
           t.onComplete = () => 
           {
               if( e == BarE.LEFT)
               {
                   isTurnLeft = false;
               }
               else if(e == BarE.RIGHT)
               {
                   isTurnRight = false;
               }
           };
        };
    }



    public void OnDestory()
    {
        EventManager.I.RemoveEvent(MainUIModel.Main_LeftOn);
        EventManager.I.RemoveEvent(MainUIModel.Main_RightOn);
    }

}
public enum BarE
{
    LEFT,
    RIGHT
}