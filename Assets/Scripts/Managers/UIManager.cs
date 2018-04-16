using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text timerText; //Done
    [SerializeField] //says VR or Non VR
    Text RoundText; //Done
    [SerializeField]
    Text RoundNumberText; //Done
    [SerializeField]
    Text Player1Points;
    [SerializeField]
    Text Player2Points;

    

    RoundManager rm;
    FurnitureDeletor fd; //For VR Power
    PlayerPlacer pp; //For Non VR Power

	// Use this for initialization
	void Awake ()
    {
        rm = FindObjectOfType<RoundManager>();
<<<<<<< HEAD
=======
        fd = FindObjectOfType<FurnitureDeletor>();
        pp = FindObjectOfType<PlayerPlacer>();
>>>>>>> dab61f6f1617efa62ea4b3a6d1b8b1578052153d
		//working on UI Manager
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        UpdateUI();
        
	}

    void UpdateUI()
    {
        timerText.text = rm.RoundTimer.ToString();
        RoundNumberText.text = "Round #" +  rm.CurrentRound.ToString();
        RoundText.text = rm.CurrentRoundState.ToString();
        Player1Points.text = "Player 1: " + rm.Player1Score.ToString();
        Player2Points.text = "Player 2: " + rm.Player2Score.ToString();
        if(fd.UsedDelete)
        {
            VRPowersLeft.text = "VR Deletes Left: 0";
        }
        else
        {
            VRPowersLeft.text = "VR Deletes Left: 1";
        }

        if(pp.JumpsLeft > 0)
        {
            NonVRPowersLeft.text = "Non VR Jumps Left: 1";
        }
        else
        {
            NonVRPowersLeft.text = "Non VR Jumps Left: 0";
        }
    }
}
