using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickNote  : MonoBehaviour
{
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked Note.");
        audioData.Play(0);
        Debug.Log("Note played.");
    }
}
