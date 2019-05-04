using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton used as a global variable to store and access the mistake count.
public class MistakeCounterSingleton : MonoBehaviour
{
    public static MistakeCounterSingleton Instance { get; private set; }

    public int mistakeCounter;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            mistakeCounter = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
