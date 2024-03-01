using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PineconeX : MonoBehaviour
{
    public GameObject pinecone1;
    public GameObject pinecone2;
    public GameObject pinecone3;
    
    // Update is called once per frame
    void Update()
    {
        XPineconeDestroyer(pinecone1, pinecone2, pinecone3);
    }

    void XPineconeDestroyer(GameObject pinecone1, GameObject pinecone2, GameObject pinecone3)
    {
        if (CapturePinecone.wrongPineconeCounter == 1)
        {
            Destroy(pinecone1);
            Debug.Log(CapturePinecone.wrongPineconeCounter);
            // FindObjectOfType<AudioManager>().Play("WrongPinecone");

        }
        else if (CapturePinecone.wrongPineconeCounter == 2)
        {
            Destroy(pinecone2);
            Debug.Log(CapturePinecone.wrongPineconeCounter);
            // FindObjectOfType<AudioManager>().Play("WrongPinecone");

        }
        else if (CapturePinecone.wrongPineconeCounter == 3)
        {
            Destroy(pinecone3);
            Debug.Log(CapturePinecone.wrongPineconeCounter);
            // FindObjectOfType<AudioManager>().Play("WrongPinecone");
            CapturePinecone.wrongPineconeCounter = 0;

            SceneManager.LoadScene("End");
        }
        else
        {
            Debug.Log("if statements passed");
        }
    }
    
    
}
