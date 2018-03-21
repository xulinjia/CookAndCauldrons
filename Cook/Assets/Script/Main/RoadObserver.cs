using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObserver : Observer
{
    public GameObject target;
    GameObject passedRoad;
    GameObject nowRoad;
    int needAddZ = 100;
    const int LENGTH = 100;
    bool isInit = false;

    public override void OnNotify(Event e)
    {
        if(!isInit)
        {
            Init(e.z);
        }
        if(CanAddRoad(e.z))
        {
            GameObject temp = passedRoad;
            temp.transform.localPosition = new Vector3(e.x, e.y, needAddZ + LENGTH);
            passedRoad = nowRoad;
            nowRoad = temp;
            needAddZ += 100;
        }
    }

    GameObject CreateRoad()
    {
        GameObject obj = passedRoad;
        passedRoad = null;
        return obj;
    }

    bool CanAddRoad(float z)
    {
        if( Mathf.Abs(z) >= needAddZ)
        {
            return true;
        }
        return false;
    }

    void Init(float z)
    {
        passedRoad = Spawner.I.SpawnBox<RoadBox>();
        passedRoad.transform.parent = target.transform;
        passedRoad.transform.localPosition = new Vector3(0, 0, 0);
        nowRoad = Spawner.I.SpawnBox<RoadBox>();
        nowRoad.transform.parent = target.transform;
        nowRoad.transform.localPosition = new Vector3(0, 0, LENGTH);
        isInit = true;
    }

}
