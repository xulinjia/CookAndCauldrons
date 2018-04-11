using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIControl : ModelUIControl
{
    public override Type AddModelDataType()
    {
        return typeof(MainUIModel);
    }

    public override List<string> AddViewList()
    {
        List<string> pahts = new List<string>();
        pahts.Add("Prefab/UI/MainView");
        return pahts;
    }
}
