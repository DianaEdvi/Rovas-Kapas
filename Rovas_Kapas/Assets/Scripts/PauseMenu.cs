using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    public Button pauseButton;
    public Button resumeButton;
    public Button optionsButton;
    public Button backButton;
    public GameObject rulesMenuUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
        // Attach the OnButtonClick method to the button's click event
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(OnButtonClick);
        }
        
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(OnResumeButtonClick);
        }

        // Disable the pause menu UI initially
        pauseMenuUI.SetActive(false);
        

        if (backButton != null)
        {
            backButton.onClick.AddListener(GoToMenu);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        if (!rulesMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }
        
    }
    
    public void OnButtonClick()
    {
        if (IsPaused)
        {
            FindObjectOfType<AudioManager>().Play("ButtonClick");
            Resume();
        }
        else
        {
            Pause();
        }    
    }
    
    public void OnResumeButtonClick()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Resume();
    }
    
    IEnumerator DelayForButtonAudio(string scene)
    {
        yield return new WaitForSeconds(0.0f);
        Debug.Log("waited");

        // Load the "Menu" scene after the delay
        SceneManager.LoadScene(scene);
    }
    void GoToMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Resume();
        StartCoroutine(DelayForButtonAudio("Menu"));
    }
    
    
}
