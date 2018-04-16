using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public enum RoundState {VRPlayer, NonVRPlayer };
    RoundState currentRoundState;
    public RoundState CurrentRoundState
    {
        get
        {
            return currentRoundState;
        }
    }

    int maxRounds;
    int currentRound;
    public int CurrentRound
    {
        get
        {
            return currentRound;
        }
    }

    [SerializeField]
    int defaultRoundTimer;

    int roundTimer;
    public int RoundTimer
    {
        get
        {
            return roundTimer;
        }
    }

    int player1Score;
    public int Player1Score
    {
        get
        {
            return player1Score;
        }
    }

    int player2Score;
    public int Player2Score
    {
        get
        {
            return player2Score;
        }
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(roundTimer <= 0)
        {
            NextRound();
        }
	}

    void NextRound()
    {
        
        roundTimer = defaultRoundTimer;
        StartCoroutine(Timer());

        if (currentRoundState == RoundState.NonVRPlayer)
        {
            currentRound++;
            currentRoundState = RoundState.VRPlayer;
        }
        else
        {
            currentRoundState = RoundState.NonVRPlayer;
        }
    }

    IEnumerator Timer()
    {
        do
        {
            yield return new WaitForSeconds(1);
            roundTimer--;
        }
        while (roundTimer >= 1);
    }
}
