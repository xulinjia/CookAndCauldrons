using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIView : UIView
{
    public Button leftBtn;
    public Button rightBtn;
    public Text score;
    string scoreTitle = "得分:";

    void Awake()
    {
        leftBtn.onClick.AddListener(OnLeftBtn);
        rightBtn.onClick.AddListener(OnRightBtn);
        SetScore(0);
    }

    public void OnLeftBtn()
    {
        Debug.Log("Left");
        EventManager.I.Dispatch(MainUIModel.Main_LeftOn, null);
    }

    public void OnRightBtn()
    {
        Debug.Log("Right");
        EventManager.I.Dispatch(MainUIModel.Main_RightOn, null);
    }

    public void SetScore(int s)
    {
        score.text = scoreTitle + s;
    }
}
