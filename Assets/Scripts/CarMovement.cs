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

    Vector3 position;

    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, boundaries.xMin, boundaries.xMax);

        transform.position = position;

        // Turn the car when moving left/right with smartphone rotation via input.acceleration.x...
        //transform.rotation = Quaternion.Euler(0f, ,0f);
    }
}


  
