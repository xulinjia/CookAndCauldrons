using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStackManager : Singleton<UIStackManager>
{
    Stack<ModelUIControl> modelStack = new Stack<ModelUIControl>();

    public void ShowModelUI()
    {
        ModelUIControl ctr = modelStack.Peek();
        ctr.Load();
    }

    public void PushModelUI(ModelUIControl mc,bool killPre = true)
    {
        if (killPre)
        {
            ModelUIControl ctr = modelStack.Pop();
            ctr.UnLoad();
        }
        modelStack.Push(mc);
        mc.Load();
    }

    public void Pop()
    {
        modelStack.Pop();
    }
}
