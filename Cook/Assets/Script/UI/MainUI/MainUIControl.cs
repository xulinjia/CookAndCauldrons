using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIControl : ModelUIControl
{
    public override BaseModel AddModelData()
    {
        return MainUIModel.I;
    }

    public override List<string> AddViewList()
    {
        List<string> pahts = new List<string>();
        pahts.Add("Prefab/UI/MainView");
        return pahts;
    }
}
