using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class SingletonData<T> : MonoBehaviour where T : new()
{
    static T instance;
    public static T I
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
