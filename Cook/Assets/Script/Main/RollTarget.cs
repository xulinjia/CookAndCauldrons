using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTarget : Subject
{

    public float speed = 0.1f;
    public RoadObserver roadObserver;
    GameObject roll;
    void Start()
    {
        roll = this.gameObject;
        AddObserver(roadObserver);
    }
	void Update ()
    {
        roll.transform.Translate(Vector3.back * speed);
        Notify(new Event(roadObserver.transform.localPosition.x, roadObserver.transform.localPosition.y, roadObserver.transform.localPosition.z));
	}
}
