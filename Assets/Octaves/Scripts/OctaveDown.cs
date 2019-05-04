using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class OctaveDown : MonoBehaviour
{

    CircleCollider2D circleCollider2D;
    Vector3 gazeVector;
    int minOctave;

    public Text OctaveText;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        minOctave = -2;
        Debug.Log("Min Octave: " + minOctave);
    }


    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            gazeVector = WorldGazePointSingleton.Instance.worldGazeVector;
            if (circleCollider2D.bounds.Contains(gazeVector))
            {
                octaveDown();
            }
        }
        if (Input.GetKeyDown("-"))
        {
            octaveDown();
        }
    }

    void OnMouseDown()
    {
        octaveDown();
    }

    void octaveDown()
    {
        Debug.Log("Current Octave: " + OctaveSingleton.Instance.currentOctave.ToString());
        Debug.Log("Min Octave: " + minOctave);
        if (OctaveSingleton.Instance.currentOctave > minOctave)
        {
            Debug.Log("Changing Octave Down");
            OctaveSingleton.Instance.currentOctave--;
            OctaveText.text = OctaveSingleton.Instance.currentOctave.ToString();
        }
    }
}