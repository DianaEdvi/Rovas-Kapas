using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPinecone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pinecone"))
        {
            Destroy(other.gameObject);
        }   
    }
    
}
