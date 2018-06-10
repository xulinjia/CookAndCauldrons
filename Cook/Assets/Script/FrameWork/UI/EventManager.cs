using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : SingletonData<EventManager>
{
    Dictionary<string, CallBack> dic = new Dictionary<string, CallBack>();

    public void AddEvent(string str,CallBack callBack)
    {
        if (!dic.ContainsKey(str))
        {
            dic.Add(str, callBack);
        }
    }

    public void RemoveEvent(string str)
    {
        if(dic.ContainsKey(str))
        {
            dic.Remove(str);
        }
    }

    public void Dispatch(string str, MessageData data)
    {
        CallBack back = dic[str];
        if(back != null)
        {
            back(data);
        }
    }
}

public delegate void CallBack(MessageData data);
