using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T>:MonoBehaviour where T : Object
{
    static T instance;
    public static T I
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();
                if(instance == null)
                {
                    Debug.LogError(typeof(T) + "is not find");
                }
            }
            return instance;
        }
    }
}
