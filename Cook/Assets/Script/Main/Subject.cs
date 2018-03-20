using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject: MonoBehaviour
{
    private Dictionary<int, Observer> observers = new Dictionary<int, Observer>();

    public void AddObserver(Observer observer)
    {
        if(!observers.ContainsKey(observer.GetHashCode()))
        {
            observers.Add(observers.GetHashCode(), observer);
        }
    }

    public void RemoveObserver(Observer observer)
    {
        if (observers.ContainsKey(observer.GetHashCode()))
        {
            observers.Remove(observer.GetHashCode());
        }
    }

    protected void Notify(Event e)
    {
        foreach (KeyValuePair<int,Observer> pair in observers)
        {
            pair.Value.OnNotify(e);
        }
    }
}
