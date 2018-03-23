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

    public void PushModelUI(ModelUIControl mc, UILayer layer = UILayer.Base)
    {
        ModelUIControl ctr = modelStack.Pop();
        ctr.UnLoad();
        modelStack.Push(mc);
        mc.Load();
    }

    public void Pop(RemoveEnum type)
    {
        switch (type)
        {
            case RemoveEnum.ABSOLUTE:
                {
                    ModelUIControl ctr = modelStack.Pop();
                    ctr.UnLoad();
                }
                break;
            case RemoveEnum.HIDE:
                {
                    ModelUIControl ctr = modelStack.Peek();
                    ctr.UnLoad();
                }
                break;
            case RemoveEnum.STAGNATE:
                {
                    ModelUIControl ctr = modelStack.Peek();
                    ctr.Hide();
                }
                break;
        }
    }

}

public enum RemoveEnum
{
    ABSOLUTE,
    HIDE,
    STAGNATE
}
