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

    //public string engineRunning = "CarEngine";
    //public string crash = "CarCrash";
    //public string tireskid = "Skid";
    //AudioManager audioManager;      
    public AudioClip tireSkid;
    public AudioClip crash;

    public Rigidbody rb;
    public Transform av;
    float horizontalMovement;

    public Transform explosionPrefab;

    Vector3 position;

    void Awake()
    {
        AudioManagerSimple.instance.carEngine.Play();        
    }

    void Start()
    {
        position = transform.position;

        /*audioManager = AudioManager.instance;
        if(audioManager == null)
        {
            Debug.Log("No AudioManager found");
        }

        audioManager.PlaySound(engineRunning);*/        

        rb = GetComponent<Rigidbody>();
        av = GetComponent<Transform>();

        InvokeRepeating("CheckRotation", 1f, 1f);

    }

    void CheckRotation()
    {
        //horizontalMovement = rb.velocity.magnitude;
        horizontalMovement = av.transform.rotation.y;
        if (horizontalMovement > 0.1)
        {
            AudioManagerSimple.instance.PlayOnDemand(tireSkid);
        }
        if (horizontalMovement < -0.1)
        {
            AudioManagerSimple.instance.PlayOnDemand(tireSkid);
        }
        Debug.Log(av.transform.rotation.y);
    }

    void Update()
    {
        
            position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            position.x = Mathf.Clamp(position.x, boundaries.xMin, boundaries.xMax);

            transform.position = position;

            float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;

            Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        
    }        

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy (gameObject);
            Transform clone = (Transform)Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(clone.gameObject, 3f);

            //audioManager.PlaySound(crash);
            AudioManagerSimple.instance.PlayOnDemand(crash);
            AudioManagerSimple.instance.carEngine.Stop();
        }
    }    
}


  
