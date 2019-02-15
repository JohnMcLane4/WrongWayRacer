using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour {

    public float vehicleSpeed2;

    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        vehicleSpeed2 = GameObject.Find("GameMaster").GetComponent<IncreaseOfSpeed>().vehicleSpeed;
        rb.velocity = transform.forward * -vehicleSpeed2;
        //rb.velocity = transform.forward * -vehicleSpeed2; 
    }
	
	// Update is called once per frame
	void Update ()
    {        
        //transform.Translate(new Vector3(0, 0, 1) * vehicleSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(gameObject);         
        }
    }
}
