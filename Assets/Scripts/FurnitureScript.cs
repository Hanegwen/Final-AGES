using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureScript : MonoBehaviour
{
    [SerializeField]
    ParticleSystem DeleteObject;

    public enum FurnitureType {Bed, Carbineet, FineChair, NoticeBoard, Plunderchest };

    [SerializeField]
    FurnitureType myType;

    public FurnitureType MyType
    {
        get
        {
            return myType;
        }
    }


    AudioSource audioSource;

    [SerializeField]
    AudioClip baseAudio;

    [SerializeField]
    AudioClip playerAudio;

    float nonPlayerLevel = .5f;
    float playerLevel = 1;

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

        //audioSource.loop = true;
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
            audioSource.volume = playerLevel;
            audioSource.clip = playerAudio;
            audioSource.Play();
        }

        else
        {
            audioSource.volume = nonPlayerLevel;
            audioSource.clip = baseAudio;
            audioSource.Play();
        }
    }

    private void OnDestroy()
    {
        Instantiate(DeleteObject, this.transform);
        
    }
}
