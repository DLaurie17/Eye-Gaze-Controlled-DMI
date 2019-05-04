using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Singleton (global variable) used to store and access the gaze point in terms of world coordinates.
public class WorldGazePointSingleton : MonoBehaviour
{
    public static WorldGazePointSingleton Instance { get; private set; }

    public Vector3 worldGazeVector;
    public Vector3 screenGazeVector;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
