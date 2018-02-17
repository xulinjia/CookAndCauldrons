using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    void Start()
    {


    }
    int code;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A " + Time.realtimeSinceStartup);
            code = TimeClockManager.I.AttachClock(2, Excute, 10);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C " + Time.realtimeSinceStartup);
            code = TimeClockManager.I.AttachTargetTimeClock(System.DateTime.Now.AddSeconds(5f), Excute);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B " + Time.realtimeSinceStartup);
            TimeClockManager.I.RemoveClock(code);
        }
    }

    void Excute()
    {
        Debug.Log(Time.realtimeSinceStartup + "--Excute");
    }
}
