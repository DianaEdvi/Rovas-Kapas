using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    
    public static bool IsPaused = false;

    public Button playButton;
    public Button optionsButton;
    public Button backButton;
    public Button quitButton;

    void Start()
    {

        if (playButton != null)
        {
            playButton.onClick.AddListener(GoToGame);
        }

        if (optionsButton != null)
        {
            optionsButton.onClick.AddListener(GoToOptions);
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(GoToMenu);
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitApplicatiom);
        }
        
    }
    
    IEnumerator DelayForButtonAudio(string scene)
    {
        yield return new WaitForSeconds(0.3f);

        // Load the "Menu" scene after the delay
        SceneManager.LoadScene(scene);
    }

    void GoToMenu()
    {
        StartCoroutine(DelayForButtonAudio("Menu"));
    }

    void GoToOptions()
    {
        StartCoroutine(DelayForButtonAudio("Options"));
    }

    void GoToGame()
    {
        StartCoroutine(DelayForButtonAudio("Game"));
    }

    void QuitApplicatiom()
    {
        Application.Quit();
        Debug.Log("Application quit");
    }
    
    
}
