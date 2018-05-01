using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    float horizontalMovement;
    float verticalMovement;

    [SerializeField]
    float rotationSpeed = 1;

    float horizontalRoation;
    float verticalRotation;

    Rigidbody rb;

    int rotation = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RoationController();
    }

    private void FixedUpdate()
    {
        MovementConroller();
        VerticleMovement();

        
    }

    void VerticleMovement()
    {
        if(Input.GetButton("UpController"))
        {
            rb.velocity += new Vector3(0, 1);
        }

        if(Input.GetButton("DownController"))
        {
            rb.velocity -= new Vector3(0, 1);
        }
    }

    void MovementConroller()
    {
        horizontalMovement = Input.GetAxis("HorizontalController");
        verticalMovement = Input.GetAxis("VerticalController");

        Vector3 move = new Vector3(horizontalMovement, 0, verticalMovement);



        rb.AddRelativeForce(move * speed);

        if(Input.GetButtonDown("VRSTOP"))
        {
            Debug.Log("Stop is Hit");
            rb.velocity = Vector3.zero;
        }
    }

    void RoationController()
    {
        
        if (Input.GetButtonDown("VRLeftTurn"))
        {
            Debug.Log("Left");
            this.gameObject.transform.Rotate(new Vector3(0, 30, 0));

            rotation += 30;
        }

        if (Input.GetButtonDown("VRRightTurn"))
        {
            Debug.Log("Right");
            this.gameObject.transform.Rotate(new Vector3(0, -30, 0));

            rotation += -30;
        }

        if (this.gameObject.transform.rotation.x != 0 || this.gameObject.transform.rotation.z != 0)
        {
            Debug.Log("Turning");
            this.gameObject.transform.rotation = Quaternion.Euler(0, rotation, 0);
            
        }
    }
}