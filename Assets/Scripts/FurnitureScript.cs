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

    float nonPlayerLevel = .2f;
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

    float audioTimer = 5;
    float baseAudioTimer = 5;
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
		if(!audioSource.isPlaying && audioTimer > 0)
        {
            PlayMusic();
        }

        if(audioTimer > 0)
        {
            audioTimer -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(PauseMusic());
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

    IEnumerator PauseMusic()
    {
        yield return new WaitForSeconds(2);
        audioTimer = baseAudioTimer;
        //Working on Audio Timer
    }
}
