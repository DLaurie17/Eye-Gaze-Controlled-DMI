using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class OctaveUp : MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    Vector3 gazeVector;
    int maxOctave;

    public Text OctaveText;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        maxOctave = 1;
        Debug.Log("Max Octave: " + maxOctave);
    }


    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            gazeVector = WorldGazePointSingleton.Instance.worldGazeVector;
            if (circleCollider2D.bounds.Contains(gazeVector))
            {
                octaveUp();
            }
        }
        if (Input.GetKeyDown("="))
        {
            octaveUp();
        }
    }

    void OnMouseDown()
    {
        octaveUp();
    }

    void octaveUp()
    {
        Debug.Log("Current Octave: " + OctaveSingleton.Instance.currentOctave.ToString());
        Debug.Log("Max Octave: " + maxOctave);

        if (OctaveSingleton.Instance.currentOctave < maxOctave)
        {
            Debug.Log("Changing Octave Up");
            OctaveSingleton.Instance.currentOctave++;
            OctaveText.text = OctaveSingleton.Instance.currentOctave.ToString();
        }
    }
}