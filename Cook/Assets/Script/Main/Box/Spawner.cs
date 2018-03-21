using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner:SingletonData<Spawner>
{
    Dictionary<Type,Box> boxDic = new Dictionary<Type, Box>();
    public Spawner()
    {
        boxDic.Add(typeof(RoadBox), new RoadBox());
    }

    public GameObject SpawnBox<T>() where T:Box,new()
    {
        return boxDic[typeof(T)].Create();
    }
}
