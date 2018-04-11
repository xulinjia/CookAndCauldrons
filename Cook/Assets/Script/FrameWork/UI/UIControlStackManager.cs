using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlStackManager : Singleton<UIControlStackManager>
{
    Stack<ModelUIControl> modelStack = new Stack<ModelUIControl>();

    public T Push<T>(UILayer layer = UILayer.Base) where T : ModelUIControl, new()
    {
        T t = new T();
        t.Load();
        modelStack.Push(t);
        return t;
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
            ModelUIControl p = modelStack.Pop();
            p.UnLoad();
        }
        else
        {
            if(modelStack.Contains(ctr))
            {
                while(modelStack.Peek() != ctr)
                {
                    ModelUIControl p = modelStack.Pop();
                    p.UnLoad();
                }
            }
        }
    }

    public void ShowTopCtr()
    {
        if (modelStack.Count == 0)
            return;
        ModelUIControl c = modelStack.Pop();
        c.Show();
    }

}
