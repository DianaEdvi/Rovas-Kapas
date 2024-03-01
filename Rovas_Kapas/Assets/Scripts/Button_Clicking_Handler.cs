using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Clicking_Handler : MonoBehaviour
{
    public AudioSource clickSound;
    
    void Start()
    {
        clickSound = GetComponent<AudioSource>();
        if (clickSound == null)
        {
            clickSound = gameObject.AddComponent<AudioSource>();
        }
    }

}
