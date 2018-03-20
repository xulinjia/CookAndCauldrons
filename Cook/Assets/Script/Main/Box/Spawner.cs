using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    public T SpawnBox<T>() where T:Box,new()
    {
        return new T();
    }
}
