using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

    private CarMovement carMovement;

    Rigidbody rb;
    float directionX;
    public float moveSpeed;

    public static bool AccelIsOff = false;

    public GameObject redLine;

    // Use this for initialization
    void Start ()
    {
        carMovement = GetComponent<CarMovement>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero, touchPosition, Color.red);

            if (touchPosition.x > 0)
            {
                carMovement.MoveRight();
            }
            else if (touchPosition.x < 0)
            {
                carMovement.MoveLeft();
            }
            else
            {
                carMovement.MoveStop();
            }
            Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
        }



        //if(Input.touchCount > 0)    //register all touches (max 5)
        //      {
        //          Touch touch = Input.GetTouch(0);

        //          Vector3 touch_Position = Camera.main.ScreenToWorldPoint(touch.position);    //Change screen coord. into world coord.

        //          if(touch_Position.x > 0)
        //          {
        //              carMovement.MoveRight();
        //          }
        //          else if (touch_Position.x < 0)
        //          {
        //              carMovement.MoveLeft();
        //          }
        //          else
        //          {
        //              carMovement.MoveStop();
        //          }
        //      }

        
    }
    
    public void AcceleratorButton()
    {
        if (AccelIsOff)
        {
            AcceleratorOn();
        }
        else
        {
            AcceleratorOff();
        }
    }

    public void AcceleratorOn()
    {
        redLine.SetActive(false);
        AccelIsOff = false;
    }

    public void AcceleratorOff()
    {
        redLine.SetActive(true);
        AccelIsOff = true;   
    }


    public void Accelerator()
    {
        directionX = Input.acceleration.x * moveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -13f, 13f), 0f, 0f);
    }

    void FixedUpdate()
    {        
        rb.velocity = new Vector3(directionX, 0f, 0f);       
    }
}
