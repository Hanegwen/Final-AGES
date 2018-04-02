using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSelector : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        FindPlayer();
    }

    void FindPlayer()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(fwd, -Vector3.up, out hit))
        {
            Debug.Log("Hitting Something");
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("furnitureLayer"))
            {
                if(Input.GetButtonDown("SelectFurnitureController")) //Input for VR Player and Exists
                {
                    if(hit.transform.gameObject.GetComponent<FurnitureScript>().IsPlayer)
                    {
                        //Found Player
                    }

                    else
                    {
                        //Didn't Find Player
                    }
                }

            }
        }
    }
}
