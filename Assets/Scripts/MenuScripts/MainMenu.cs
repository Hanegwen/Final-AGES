using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Canvas MainMenuCanvas;
    [SerializeField]
    Canvas InstructionsCanvas;
    [SerializeField]
    Canvas CreditsCanvas;

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void InstructionsButton()
    {
        InstructionsCanvas.enabled = true;

        MainMenuCanvas.enabled = false;
    }

    public void CreditsButton()
    {
        CreditsCanvas.enabled = true;

        MainMenuCanvas.enabled = false;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        MainMenuCanvas.enabled = true;

        InstructionsCanvas.enabled = false;
        CreditsCanvas.enabled = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}