using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseOfSpeed : MonoBehaviour {

    public float vehicleSpeed;
    public float minSpeed = 15f;
    public float maxSpeed = 100f;

    static float t = 0.0f;

	// Use this for initialization
	void Start ()
    {
        vehicleSpeed = 15f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        t += 0.001f * Time.deltaTime;

        vehicleSpeed = Mathf.Lerp(minSpeed, maxSpeed, t);
	}
}
