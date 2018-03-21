using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    protected GameObject Obj;
    protected string path;
    public Box()
    {
        Load();
    }

    public virtual GameObject Create()
    {
        return Instantiate(Obj);
    }

    public virtual void Load()
    {
        Obj = Resources.Load(path) as GameObject;
    }
}
