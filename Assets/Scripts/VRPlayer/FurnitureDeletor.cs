using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDeletor : MonoBehaviour
{
    [SerializeField]
    bool usedDelete = false;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!usedDelete && Input.GetButtonDown("RandomPowerController")) // At this time Y (4/12/18)
        {
            Delete();
        }
	}

    void Delete()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 5))
        {
            Debug.Log("Hitting Something");
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("FurnitureLayer"))
            {
                Debug.Log("Click The Button");
                if (Input.GetButtonDown("SelectFurnitureKeyboard")) //Exists
                {
                    Debug.Log("I Hit Something with the correct layer");
                    if (hit.transform.gameObject.GetComponent<FurnitureScript>().IsPlayer)
                    {
                        Debug.Log("This is the player");
                        //Found Player
                    }

                    else
                    {
                        Destroy(hit.transform.gameObject);
                        usedDelete = true;
                        //Didn't Find Player
                    }
                }
            }
        }
    }
}
