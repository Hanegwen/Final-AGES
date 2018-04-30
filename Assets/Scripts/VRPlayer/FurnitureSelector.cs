using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureSelector : MonoBehaviour
{
    [SerializeField]
    Text activeFurniture;

    bool correctGuess;
    public bool CorrectGuess
    {
        get
        {
            return correctGuess;
        }
    }

    bool minusTimer = false;
    public bool MinusTimer
    {
        get
        {
            return minusTimer;
        }

        set
        {
            minusTimer = value;
        }
    }


    RaycastHit hit;
    // Use this for initialization
    void Start ()
    {
        activeFurniture.text = "";
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        FindPlayer();
        
    }

    void FindPlayer()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(transform.position, fwd, out hit, 5))
        {
            Debug.Log("VR: Hitting Something");
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("furnitureLayer"))
            {
                activeFurniture.text = hit.transform.gameObject.name;
                Debug.Log("VR: Hitting Corrcet Layer");
                if(Input.GetButtonDown("SelectFurnitureController")) //Input for VR Player and Exists
                {
                    if(hit.transform.gameObject.GetComponent<FurnitureScript>().IsPlayer)
                    {
                        correctGuess = true;
                        Debug.Log("Game is Over");
                        //Found Player
                    }

                    else
                    {
                        minusTimer = true;
                        //timer--;
                        Debug.Log("Wrong Guess");
                        //Didn't Find Player
                    }
                }

            }
        }
    }

    public void OtherTurn()
    {
        activeFurniture.text = "Other Persons Turn";
    }

    public void MyTurn()
    {
        activeFurniture.text = "My Turn";
    }
}
