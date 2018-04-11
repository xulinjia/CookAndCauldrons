﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingControl : ModelUIControl
{
    public override BaseModel AddModelData()
    {
        return LoadingModel.I;
    }

    public override List<string> AddViewList()
    {
        List<string> list = new List<string>();
        list.Add("Prefab/UI/LoadView");
        return list;
    }
}
