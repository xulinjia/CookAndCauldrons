using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : SingletonData<ModelManager>
{
    Dictionary<Type, BaseModel> modelDataDir = new Dictionary<Type, BaseModel>();

    public void SetModelData(Type dataType)
    {
        if (!modelDataDir.ContainsKey(dataType))
            modelDataDir[dataType] = Activator.CreateInstance(dataType) as BaseModel; 
    }

    public BaseModel GetModelData(Type dataType)
    {
        if (modelDataDir.ContainsKey(dataType))
            return modelDataDir[dataType];
        else
            return null;
    }
}
