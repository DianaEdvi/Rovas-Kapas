using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainingLetters : MonoBehaviour
{
    
    public TextMeshProUGUI remainingLetters;

    // Update is called once per frame
    void Update()
    {
        remainingLetters.text = CapturePinecone.currentWord;
    }
}
