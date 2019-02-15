using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Own class for Boundaries so it has its own section in the inspector
[System.Serializable]
public class Boundaries
{
    public float xMin, xMax;
}

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{
    public Boundaries boundaries;
    public float speed;

    //public float tilt;
    //private Rigidbody rb;

    float smooth = 5.0f;
    float tiltAngle = 40.0f;

    Vector3 position;

    void Start()
    {
        position = transform.position;

        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, boundaries.xMin, boundaries.xMax);

        transform.position = position;

        // Turn the car when moving left/right with smartphone rotation via input.acceleration.x...
        //transform.rotation = Quaternion.Euler(0f, ,0f);

        float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;

        Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

    void FixedUpdate()
    {
        //rb.rotation = Quaternion.Euler(0f, GetComponent<Rigidbody>().velocity.x * -tilt, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy (gameObject);
            //Transform clone = (Transform)Instantiate(ExplosionEffectPrefab, spawnPoint.position, spawnPoint.rotation);
            //Destroy(clone.gameObject, 3f);
        }
    }
}


  
