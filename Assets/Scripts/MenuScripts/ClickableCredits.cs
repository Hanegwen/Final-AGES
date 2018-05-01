using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableCredits : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ClickCredits()
    {
        Application.OpenURL("https://goo.gl/RKV5G9");
        Application.OpenURL("https://goo.gl/CHb2hH");

        Application.OpenURL("http://ccmixter.org/files/nickleus/30605");
        Application.OpenURL("http://ccmixter.org/files/JeffSpeed68/56643");
        Application.OpenURL("http://ccmixter.org/files/fjsamiryi/50518");
        Application.OpenURL("http://ccmixter.org/files/nickleus/21672");
    }
}
