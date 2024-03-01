using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class WordDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    
    // private string = "\ud803\udc80 \ud803\udc81"
    [FormerlySerializedAs("alphabetTXT")] public TextAsset wordsTXT;
    public static string currentWord = "";

    public TextMeshProUGUI displayText;
    private string[] wordStrings;
    private int currentIndex = -1;
    private int currentLetterIndex = -1;
    
    void Start()
    {
        if (wordsTXT != null)
        {
            wordStrings = wordsTXT.text.Split(' ');
        }
        else
        {
            Debug.Log("letter not assigned");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //condition that switches word
        {
            currentWord = DisplayRandomWord();
            displayText.text = currentWord;
            // string content = displayText.text;
            // int[] visibleCharacterCount = StringInfo.ParseCombiningCharacters(content);
            //
            // string content2 = displayText.text;
            // int visibleCharacterCount2 = 0;
            //
            // TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(content2);
            // while (enumerator.MoveNext())
            // {
            //     visibleCharacterCount2++;
            // }
            //
            //
            // Debug.Log("Wordlength sent to file: " + currentWord.Length);
            // Debug.Log("after removing invisibles: " + visibleCharacterCount.Length);
            // Debug.Log("Visible Character Count: " + visibleCharacterCount2);
            //
            // writeToFile();
        }
        if (Input.GetMouseButtonDown(1)) //condition that changes highlighted letter 
        {
            Debug.Log("mouse button pressed");
            // displayText.text = highlightLetter(currentWord);
        }
        
    }

    string DisplayRandomWord()
    {
        if (wordStrings != null && wordStrings.Length > 0)
        {
            int randomIndex = Random.Range(0, wordStrings.Length);

            while (randomIndex == currentIndex)
            {
                randomIndex = Random.Range(0, wordStrings.Length);
            }

            currentIndex = randomIndex;
            // displayText.text = letters[currentIndex];
        }
        return wordStrings[currentIndex];
    }

    public string getCurrentWord()
    {
        return currentWord;
    }

    // string highlightLetter(string word)
    // {
    //     string newWord = "";
    //     for (int i = 0; i < word.Length; i++)
    //     {
    //         char[] chars = word.ToCharArray();
    //         newWord = newWord + "<color="white">" + chars[i];
    //     }
    //
    //     return newWord;
    // }
    public string filePath = "Assets/OutputText.txt";
    public void writeToFile()
    {
        string textContent = displayText.text;

        try
        {
            // Write to the file
            File.WriteAllText(filePath, textContent);
            Debug.Log("Text written to file: " + filePath);
        }
        catch (Exception e)
        {
            Debug.LogError("Error writing text to file: " + e.Message);
        }
    }
    
}
