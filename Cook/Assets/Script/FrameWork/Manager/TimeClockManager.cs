using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeClockManager : Singleton<TimeClockManager>
{
    List<TimeClockData> ExcClockList = new List<TimeClockData>();
    List<TimeClockData> delClockList = new List<TimeClockData>();
    void Update()
    {
        foreach (TimeClockData clock in ExcClockList)
        {
            if(clock.IsExcute())
                clock.Excute();
        }

        //Add Excute False To DelList
        foreach (TimeClockData clock in ExcClockList)
        {
            if(!clock.isActive)
            {
                if (!delClockList.Contains(clock))
                    delClockList.Add(clock);
            }
        }
        //Remove DelList
        for(int i = 0; i < delClockList.Count; i++)
        {
            TimeClockData clock = ExcClockList.Find(x => x == delClockList[i]);
            if(clock != null )
            {
                ExcClockList.Remove(clock);
            }
        }
        delClockList.Clear();
    }

    public int AttachClock(float laterTime, Action act, int loop = 1)
    {
        TimeClockData clock = new TimeClockData();
        clock.laterTime = laterTime;
        clock.loop = loop;
        clock.act = act;
        clock.startTime = Time.realtimeSinceStartup;
        ExcClockList.Add(clock);
        return clock.GetHashCode();
    }

    public int AttachTargetTimeClock(DateTime targetTime,Action act)
    {
        TimeSpan span = targetTime - TimeManager.I.GetCurrentTime();
        float sec = (float)span.TotalSeconds;
        return AttachClock(sec, act);
    }

    public void RemoveClock(int hashCode)
    {
        TimeClockData clock = ExcClockList.Find(x => x.GetHashCode() == hashCode);
        if(clock != null )
        {
            if(!delClockList.Contains(clock))
                delClockList.Add(clock);
        }
    }
}

 class TimeClockData
{
    public float laterTime;
    public int loop;
    public Action act;
    public bool isActive = true;
    public float startTime;
    int curloop;

    public bool IsExcute()
    {
        if (!isActive)
            return false;
        return Time.realtimeSinceStartup >= startTime + (curloop + 1) * laterTime;
    }

    public void Excute()
    {
        curloop++;
        if (act == null)
        {
            isActive = false;
            return;
        }
        act();
        if (curloop < loop)
        {
            isActive = true;            
        }
        else
        {
            isActive = false;
        }
    }
}
