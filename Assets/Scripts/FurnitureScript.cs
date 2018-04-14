using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureScript : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip baseAudio;

    [SerializeField]
    AudioClip playerAudio;

    bool isPlayer;
    public bool IsPlayer
    {
        get
        {
            return isPlayer;
        }

        set
        {
            isPlayer = value;
        }
    }
	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(playerAudio == null || baseAudio == null) // Debug for me
        {
            throw new NotImplementedException("Never did audio");
        }
		if(!audioSource.isPlaying)
        {
            PlayMusic();
        }
	}

    void PlayMusic()
    {
        if(IsPlayer)
        {
            audioSource.clip = playerAudio;
            audioSource.Play();
        }

        else
        {
            audioSource.clip = baseAudio;
            audioSource.Play();
        }
    }
}
