using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTarget : Subject
{

    public float speed = 0.1f;
    GameObject road;
    void Start()
    {
        road = this.gameObject;
    }
	void Update ()
    {
        road.transform.Translate(Vector3.back * speed);
	}
}
