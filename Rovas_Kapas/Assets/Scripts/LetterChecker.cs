using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class LetterChecker : MonoBehaviour
{
    
    
  

    IEnumerator DelayedCheckForObjects()
    {
        yield return new WaitForSeconds(1.0f); // Adjust the delay as needed

        StartCoroutine(letterChecker());
    }
    public TextMeshProUGUI textWord = null;

    IEnumerator letterChecker()
    {
        while (true)
        {
            GameObject word = GameObject.FindGameObjectWithTag("Word");
            GameObject letter = GameObject.FindGameObjectWithTag("Letter");

            if (word != null && letter != null)
            {
                Debug.Log("Word and letter objects are not null");

                TextMeshProUGUI wordText = word.GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI letterText = letter.GetComponent<TextMeshProUGUI>();

                if (wordText != null && letterText != null)
                {
                    Debug.Log("Texts are not null");
                    string wordString = wordText.text;
                    string letterString = letterText.text;

                    Debug.Log("Word Text: " + wordString);
                    Debug.Log("Letter Text: " + letterString);

                    textWord.text = wordString;
                    

                    if (!string.IsNullOrEmpty(wordString) && !string.IsNullOrEmpty(letterString))
                    {
                        Debug.Log("Neither string is empty");
                    }
                }

                break; // Exit the loop once conditions are checked
            }

            yield return null; // Wait for the next frame
        }

    }

}
