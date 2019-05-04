using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton used as a global variable to store and access the current octave of notes accessible to the user.
public class OctaveSingleton : MonoBehaviour
{
    public static OctaveSingleton Instance { get; private set; }

    public int currentOctave;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentOctave = 0; // 0 is the middle octave (includes middle C)
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
