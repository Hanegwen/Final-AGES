using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlacer : MonoBehaviour
{
    [SerializeField]
    Transform spawnLocation;
    [SerializeField]
    List<GameObject> spawnableObjects;
    int spawnableObjectAmount = 0;
    int activeSpawnableObjectsNum = 0;
    GameObject activeSpawnableObject;

    [SerializeField]
    List<GameObject> spawnedObject;
    int spawnedObjectAmount = 0;

    [SerializeField]
    LayerMask FurnitureLayer;
	// Use this for initialization
	void Start ()
    {
        activeSpawnableObject = Instantiate(spawnableObjects[0], spawnLocation);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        spawnableObjectAmount = spawnableObjects.Count;


        if(Input.GetButtonDown("SelectFurnitureKeyboard")) //Exists
        {
            if (activeSpawnableObject != null)
            {
                PlaceFurniture();
            }
        }

        if(spawnableObjects.Count == 0)
        {
            //Works checked with Log
            //Debug.Log(spawnableObjects.Count);
            ChooseFurniture();
        }

        //if(Input.GetButtonDown("NextFurnitureKeyboard")) //Exists
        //{
        //    NextFurniture();
        //}
	}

    void PlaceFurniture() //Done
    {
        if (spawnableObjects.Count != 0)
        {
            activeSpawnableObject.GetComponent<Rigidbody>().useGravity = true;
            activeSpawnableObject.transform.parent = null;

            spawnedObject.Add(activeSpawnableObject);

            spawnableObjects.Remove(spawnableObjects[activeSpawnableObjectsNum]);
        }

        
        if (spawnableObjects.Count != 0)
        {
            activeSpawnableObject = Instantiate(spawnableObjects[0], spawnLocation);
            activeSpawnableObjectsNum = 0;
        }
        else
        {
            Debug.Log("Out of Furniture");
        }
    }

    //void NextFurniture()
    //{
    //    Destroy(activeSpawnableObject);
    //    activeSpawnableObjectsNum++;
    //    if(activeSpawnableObjectsNum + 1 > spawnableObjectAmount)
    //    {
    //        activeSpawnableObjectsNum = 0;
    //    }
    //    activeSpawnableObject = Instantiate(spawnableObjects[activeSpawnableObjectsNum], spawnLocation);

    //    //Cycles through the furniture options
    //}

    void ChooseFurniture()
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
                    this.gameObject.SetActive(false);
                    hit.transform.GetComponentInChildren<Camera>().enabled = true;
                    hit.transform.gameObject.GetComponent<FurnitureScript>().IsPlayer = true;
                }
            }
        }

        //Lets the player decide which furniture they are
    }
}
