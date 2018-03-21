using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer:MonoBehaviour
{
    public abstract void OnNotify(Event e); 
}

public class Event
{
    public Event(float x, float y,float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public float x;
    public float y;
    public float z;
} 
