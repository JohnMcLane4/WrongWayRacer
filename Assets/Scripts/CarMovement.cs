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

    float smooth = 10.0f;
    float tiltAngle = 40.0f;

    public string engineRunning = "CarEngine";
    public string crash = "CarCrash";
    public string tireskid = "Skid"; 
    AudioManager audioManager;

    public Rigidbody rb;    
    float horizontalMovement;

    Vector3 position;

    void Start()
    {
        position = transform.position;

        audioManager = AudioManager.instance;
        if(audioManager == null)
        {
            Debug.Log("No AudioManager found");
        }

        audioManager.PlaySound(engineRunning);

        rb = GetComponent<Rigidbody>();       
    }

    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, boundaries.xMin, boundaries.xMax);

        transform.position = position;

        float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;

        Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        horizontalMovement = rb.velocity.magnitude;
        if(horizontalMovement > 0.1)
        {
            audioManager.PlaySound(tireskid);
        }
        Debug.Log(rb.velocity);
    }        

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy (gameObject);
            //Transform clone = (Transform)Instantiate(ExplosionEffectPrefab, spawnPoint.position, spawnPoint.rotation);
            //Destroy(clone.gameObject, 3f);

            audioManager.PlaySound(crash);
        }
    }
}


  
