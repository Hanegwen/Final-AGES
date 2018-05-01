using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameMenu : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayAgain()
    {
        Destroy(FindObjectOfType<RoundManager>().gameObject);
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        Destroy(FindObjectOfType<RoundManager>().gameObject);
        SceneManager.LoadScene("Menu");
    }
}
