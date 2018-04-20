using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    static RoundManager roundManagerInstance;
    PlayerPlacer pp;
    FurnitureSelector fs;
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
	void Awake ()
    {
        DontDestroyOnLoad(this);
        if(roundManagerInstance == null)
        {
            roundManagerInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        pp = FindObjectOfType<PlayerPlacer>();
        fs = FindObjectOfType<FurnitureSelector>();
	}

    private void Start()
    {

        currentRoundState = RoundState.NonVRPlayer;
        StartingRound();
    }

    // Update is called once per frame
    void Update ()
    {
        ControlDisplays(); //Second Monitor for Testing

        if(pp == null)
        {
            pp = FindObjectOfType<PlayerPlacer>();
            
        }
        if (fs == null)
        {
            fs = FindObjectOfType<FurnitureSelector>();
        }
        if(roundTimer <= 0)
        {
            NextRound();
        }
        if(pp.InFurniture && pp.gameObject.GetComponent<Camera>().isActiveAndEnabled)
        {
            NextRound();
        }
        if (fs != null)
        {
            ForceNextRound();
            MinusTimer();
        }
	}

    void StartingRound()
    {
        currentRound++;
        roundTimer = defaultRoundTimer;
        StartCoroutine(Timer());
    }

    void NextRound()
    {
        StopAllCoroutines();
        roundTimer = defaultRoundTimer;
        StartCoroutine(Timer());

        if (currentRoundState == RoundState.NonVRPlayer)
        {
            Debug.Log("1");
            do
            {
                pp.PlaceFurniture();
            }
            while (pp.spawnableObjects.Count != 0);
            pp.ForcePlace();
            currentRound++;
            currentRoundState = RoundState.VRPlayer;
            fs.gameObject.SetActive(true);
            
        }
        else
        {
            Debug.Log("2");
            player1Score++; //Player got it
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            fs.gameObject.SetActive(false);
            pp.gameObject.SetActive(true);
            currentRoundState = RoundState.NonVRPlayer;
        }
    }

    void MinusTimer()
    {
        if(fs.MinusTimer)
        {
            roundTimer -= 5;
            fs.MinusTimer = false;
        }
    }

    void ForceNextRound()
    {
        if(fs.CorrectGuess)
        {
            player2Score++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    void ControlDisplays()
    {
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();

            var camera1 = pp.GetComponent<Camera>();
            var camera2 = fs.GetComponent<Camera>();


            camera1.targetDisplay = 0;
            camera2.targetDisplay = 1;
        }
    }
}
