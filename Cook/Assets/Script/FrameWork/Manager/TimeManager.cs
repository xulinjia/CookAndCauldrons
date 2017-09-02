using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager:Singleton<TimeManager>
{
    public DateTime GetCurrentTime()
    {
        return DateTime.Now;
    }
}
