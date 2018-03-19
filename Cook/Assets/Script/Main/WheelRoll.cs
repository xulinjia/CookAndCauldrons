using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRoll : MonoBehaviour {

    public GameObject road;
    public float speed = 1;
    public float sum = 0f;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        road.transform.Translate(Vector3.left * speed);
        //road.transform.localPosition = new Vector3(road.transform.localPosition.x - 0.1f, road.transform.localPosition.y, road.transform.localPosition.z);
        Debug.Log(Vector3.left * speed);
	}
}
