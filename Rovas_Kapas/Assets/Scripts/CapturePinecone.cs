using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CapturePinecone : MonoBehaviour
{
    private int letterIndex = 0;
    public static int wrongPineconeCounter = 0;

    public static string currentWord = "";

    private string originalWord = ""; 
    

    // Update is called once per frame
    void Update()
    {
        if (!originalWord.Equals(WordDisplay.currentWord))
        {
            originalWord = WordDisplay.currentWord;
            currentWord = originalWord;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pinecone"))
        {
            Debug.Log("Captured!");
            
            string pineconeLetter = other.GetComponentInChildren<TextMeshProUGUI>().text;
            
            if (currentWord.Contains(pineconeLetter))
            {
                FindObjectOfType<AudioManager>().Play("CorrectPinecone");
                Debug.Log("Before removing");
                displayHexString(currentWord);
                Debug.Log("letter is in word!");
                
                currentWord = currentWord.Replace(pineconeLetter, "");
                Debug.Log("after removing");
                displayHexString(currentWord);
                
                if (currentWord.Length == 1)
                {
                    Debug.Log("finsihed");
                    SceneManager.LoadScene("End");
                    FindObjectOfType<AudioManager>().Play("EndGame");

                }
            }

            else
            {
                FindObjectOfType<AudioManager>().Play("WrongPinecone");
                Debug.Log("Dont catch this guy!");
                wrongPineconeCounter++;
                if (wrongPineconeCounter == 3)
                {
                    Debug.Log("Game over!");
                }
            }
            
            Destroy(other.gameObject);
        }   
    }

    void displayHexString(string s)
    {
        byte[] wordBytes = Encoding.UTF8.GetBytes(s);
        string wordHexString = BitConverter.ToString(wordBytes);
        Debug.Log("word hex: " + wordHexString);
    }
    
}
