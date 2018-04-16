using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlacer : MonoBehaviour
{
    bool inFurniture = false;
    public bool InFurniture { get { return inFurniture; } }


    [SerializeField]
    GameObject activeGameObject;

    [SerializeField]
    Transform spawnLocation;
    [SerializeField]
    public List<GameObject> spawnableObjects;
    int spawnableObjectAmount = 0;
    int activeSpawnableObjectsNum = 0;
    GameObject activeSpawnableObject;

    [SerializeField]
    List<GameObject> spawnedObject;
    int spawnedObjectAmount = 0;

    [SerializeField]
    LayerMask FurnitureLayer;

    [SerializeField]
    int jumpsLeft;

    public int JumpsLeft
    {
        get
        {
            return jumpsLeft;
        }
    }

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

        if(Input.GetButtonDown("JumpKeyboard") && jumpsLeft > 0 && spawnableObjects.Count == 0)
        {
            Jump();
        }


        //if(Input.GetButtonDown("NextFurnitureKeyboard")) //Exists
        //{
        //    NextFurniture();
        //}
	}

    public void ForcePlace()
    {
        Debug.Log("Force Place");
        
        

        spawnedObject[0].transform.GetComponentInChildren<Camera>().enabled = true;
        spawnedObject[0].transform.gameObject.GetComponent<FurnitureScript>().IsPlayer = true;
        activeGameObject = spawnedObject[0];

        this.gameObject.SetActive(false);
        this.transform.GetComponentInChildren<Camera>().enabled = false;

    }

    void Jump()
    {
        Debug.Log("I Jumped");
        jumpsLeft--;

        Debug.Log("Deactivate Me");
        this.gameObject.SetActive(false);
        activeGameObject.transform.GetComponentInChildren<Camera>().enabled = false;
        activeGameObject.transform.gameObject.GetComponent<FurnitureScript>().IsPlayer = false;


        if(spawnedObject[0] != activeGameObject)
        {
            Debug.Log("In Any");
            spawnedObject[0].transform.GetComponentInChildren<Camera>().enabled = true;
            spawnedObject[0].transform.gameObject.GetComponent<FurnitureScript>().IsPlayer = true;
            activeGameObject = spawnedObject[0];
        }
        else
        {
            Debug.Log("In Not Me");
            spawnedObject[2].transform.GetComponentInChildren<Camera>().enabled = true;
            spawnedObject[2].transform.gameObject.GetComponent<FurnitureScript>().IsPlayer = true;
            activeGameObject = spawnedObject[2];
        }

        Debug.Log("Should be in New furniture");

    }

    public void PlaceFurniture() //Done
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
                    this.gameObject.GetComponent<PlayerMovement>().enabled = false;
                    hit.transform.GetComponentInChildren<Camera>().enabled = true;
                    hit.transform.gameObject.GetComponent<FurnitureScript>().IsPlayer = true;

                    activeGameObject = hit.transform.gameObject;
                    inFurniture = true;
                }
            }
        }

        //Lets the player decide which furniture they are
    }
}
