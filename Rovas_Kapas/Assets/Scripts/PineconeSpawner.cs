using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PineconeSpawner : MonoBehaviour
{
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    public GameObject pineconePrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    public TextMeshProUGUI displayLetter;
    public TextAsset alphabetTXT;
    private string[] letters;
    public float height = Screen.height;
    public GameObject rulesMenuUI;
    private string currentLetter;
    
    // Start is called before the first frame update
    void Start()
    {
        if (alphabetTXT != null)
        {
            letters = alphabetTXT.text.Split(" ");
            Debug.Log("Letters in text file");
        }
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, height, MainCamera.transform.position.z));
        StartCoroutine(PineconeWaves());
    }

    private void generatePinecone(){
        if (!rulesMenuUI.activeSelf)
        {
            GameObject pinecone = Instantiate(pineconePrefab) as GameObject;
            float prefabHeight = pinecone.GetComponent<Renderer>().bounds.size.y;
            
            pinecone.transform.position = new Vector2(Random.Range(10, screenBounds.x -10), screenBounds.y);
            displayLetter = pinecone.GetComponentInChildren<TextMeshProUGUI>();

            if (displayLetter != null)
            {
                
                displayLetter.transform.position = new Vector3(pinecone.transform.position.x + 92, pinecone.transform.position.y - 26, pinecone.transform.position.z);
                // currentLetter = displayLetter.text;
                displayLetter.text = DisplayRandomLetter();

            }
        }
    }

    IEnumerator PineconeWaves(){
        
            while(true){
                yield return new WaitForSeconds(respawnTime);
                generatePinecone();
            } 
    }
    
    public string DisplayRandomLetter()
    {
        int currentIndex = -1;
        
        if (letters != null && letters.Length > 0)
        {
            int randomIndex = Random.Range(0, letters.Length);
            
            while (randomIndex == currentIndex)
            {
                randomIndex = Random.Range(0, letters.Length);
            }
            currentIndex = randomIndex;
            return letters[currentIndex];

        }
        return "No";
    }
}
