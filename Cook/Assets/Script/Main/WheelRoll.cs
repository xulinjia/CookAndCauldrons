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
        Debug.Log(Vector3.left * speed);
	}
}
