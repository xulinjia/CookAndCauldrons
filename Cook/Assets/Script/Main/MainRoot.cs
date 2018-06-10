using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainRoot : MonoBehaviour
{
    public GameObject LeftObj;
    public GameObject RightObj;

    void Awake()
    {
        EventManager.I.AddEvent(MainUIModel.Main_LeftOn, OnLeftBar);
        EventManager.I.AddEvent(MainUIModel.Main_RightOn, OnRightBar);
    }

    public void OnLeftBar(MessageData data)
    {
        RotateTarget(LeftObj);
    }

    public void OnRightBar(MessageData data)
    {
        RotateTarget(RightObj);
    }

    [ContextMenu("Left")]
    public void TestLeft()
    {
        RotateTarget(LeftObj);
    }

    [ContextMenu("Right")]
    public void TestRight()
    {
        RotateTarget(RightObj);
    }

    public void RotateTarget(GameObject target)
    {
        //target.transform.Rotate(new Vector3(0, 0, 90));
        Transform trans = target.transform;
        Tween tween = trans.DORotate(new Vector3(0, 0, 90), 0.3f, RotateMode.LocalAxisAdd);
        tween.onComplete = () => tween = trans.DORotate(new Vector3(0, 0, -90), 0.3f, RotateMode.LocalAxisAdd);
    }
    public void OnDestory()
    {
        EventManager.I.RemoveEvent(MainUIModel.Main_LeftOn);
        EventManager.I.RemoveEvent(MainUIModel.Main_RightOn);
    }

}
