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
    LayerMask furnitureLayer;
	// Use this for initialization
	void Start ()
    {
        activeSpawnableObject = spawnableObjects[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        spawnableObjectAmount = spawnableObjects.Count;

        if(Input.GetButtonDown("SelectFurnitureKeyboard"))
        {
            ChooseFurniture();
        }

        if(Input.GetButtonDown("NextFurnitureKeyboard"))
        {
            NextFurniture();
        }
	}

    void NextFurniture()
    {
        activeSpawnableObjectsNum++;
        if(activeSpawnableObjectsNum + 1 > spawnableObjectAmount)
        {
            activeSpawnableObjectsNum = 0;
        }


        //Cycles through the furniture options
    }

    void ChooseFurniture()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(fwd, -Vector3.up, out hit))
        {
            Debug.Log("Hitting Something");
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("furnitureLayer"))
            {

            }
        }
        //Lets the player decide which furniture they are
    }
}
