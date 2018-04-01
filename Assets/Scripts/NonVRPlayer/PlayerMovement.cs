using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //MovementController();
        MovementKeyboard();
    }

    void MovementController()
    {
        horizontalMovement = Input.GetAxis("HorizontalController");
        verticalMovement = Input.GetAxis("VerticalController");

        Vector3 move = new Vector3(horizontalMovement, 0, verticalMovement);



        rb.AddRelativeForce(move * speed);

        if (Input.GetKeyDown(KeyCode.Space)) //For Debugging
        {
            rb.velocity = Vector3.zero;
        }

        //Rotation on Controller Broken

        horizontalRoation += -1 * rotationSpeed * Input.GetAxis("Mouse Y");
        
        verticalRotation -= -1 * rotationSpeed * Input.GetAxis("Mouse X ");

        transform.eulerAngles = new Vector3(horizontalRoation, verticalRotation, 0.0f);
    }

    void MovementKeyboard()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalMovement, 0, verticalMovement);
        
        

        rb.AddRelativeForce(move * speed);

        if (Input.GetKeyDown(KeyCode.Space)) //For Debugging
        {
            rb.velocity = Vector3.zero;
        }

        horizontalRoation += -1 * rotationSpeed * Input.GetAxis("Mouse Y");
        verticalRotation -= -1 * rotationSpeed * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(horizontalRoation, verticalRotation, 0.0f);
    }

}
