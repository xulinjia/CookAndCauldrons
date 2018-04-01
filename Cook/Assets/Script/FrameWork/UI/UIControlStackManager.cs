using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlStackManager : Singleton<UIControlStackManager>
{
    Stack<ModelUIControl> modelStack = new Stack<ModelUIControl>();

    public void Push(ModelUIControl mc, UILayer layer = UILayer.Base)
    {
        if (modelStack.Count != 0)
        {
            ModelUIControl ctr = modelStack.Pop();
            ctr.UnLoad();
        }
        modelStack.Push(mc);
    }

    public ModelUIControl Peek()
    {
        if(modelStack.Count == 0)
        {
            return null;
        }
        return modelStack.Peek();
    }

    public void Pop(ModelUIControl ctr = null)
    {
        if (modelStack.Count == 0)
            return;
        if (ctr == null)
        {
            modelStack.Pop();
        }
        else
        {
            if(modelStack.Contains(ctr))
            {
                while(modelStack.Peek() != ctr)
                {
                    modelStack.Pop();
                }
            }
        }
    }

}
