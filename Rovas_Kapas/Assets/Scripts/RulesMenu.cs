using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RulesMenu : MonoBehaviour
{
    public GameObject rulesMenuUI;

    public Button kezdesButton;

    public Button visszaButton;
    
    // Start is called before the first frame update
    void Start()
    {
        rulesMenuUI.SetActive(true);

        if (kezdesButton != null)
        {
            kezdesButton.onClick.AddListener(StartGame);
        }

        if (visszaButton != null)
        {
            visszaButton.onClick.AddListener(GoToMenu);
        }
        
    }
    
    void StartGame()
    {
        StartCoroutine(StartGameWithDelay());
    }

    IEnumerator StartGameWithDelay()
    {
        // Delay setting rulesMenuUI to false by 0.5 seconds (adjust as needed)
        yield return new WaitForSeconds(0.3f);

        // Set the rulesMenuUI to false after the delay
        rulesMenuUI.SetActive(false);
    }

    void GoToMenu()
    {
        StartCoroutine(GoToMenuWithDelay());
    }

    IEnumerator GoToMenuWithDelay()
    {
        // Delay setting rulesMenuUI to false by 0.5 seconds (adjust as needed)
        yield return new WaitForSeconds(0.3f);

        // Load the "Menu" scene after the delay
        SceneManager.LoadScene("Menu");
    }
}
