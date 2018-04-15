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

    [SerializeField]
    Text VRPowersLeft;

    [SerializeField]
    Text NonVRPowersLeft;

    RoundManager rm;

	// Use this for initialization
	void Start ()
    {
        rm = FindObjectOfType<RoundManager>();
		working on UI Manager
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
    }
}
