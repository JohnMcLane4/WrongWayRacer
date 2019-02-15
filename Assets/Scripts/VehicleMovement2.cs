using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement2 : MonoBehaviour {

    public float vehicleSpeed2 = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,0,1) * vehicleSpeed2 * Time.deltaTime);
	}
}
