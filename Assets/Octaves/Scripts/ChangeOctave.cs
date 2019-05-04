using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

// Scipt for octave control.

public class ChangeOctave : MonoBehaviour
{
    Vector3 worldGaze;
    Vector3 screenGaze;
    int maxOctave;
    int minOctave;
    string logPath = "Assets/Logs/log.txt";
    string objectName;
    string timeStamp;

    public Text OctaveText;

    void Start()
    {
        timeStamp = DateTime.UtcNow.ToString() + ":" + DateTime.UtcNow.Millisecond.ToString();
        maxOctave = 2;
        minOctave = -2;
        writeToLog("ChangeOctave.cs started", true, false, false);
        writeToLog("Max Octave: " + maxOctave + ", Min Octave:" + minOctave, true, false, false);
    }


    void Update()
    {
        worldGaze = WorldGazePointSingleton.Instance.worldGazeVector;
        screenGaze = WorldGazePointSingleton.Instance.screenGazeVector;
        timeStamp = DateTime.UtcNow.ToString() + ":" + DateTime.UtcNow.Millisecond.ToString();

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            octaveDown();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            octaveUp();
        }
    }

    //decrements the current octave and stores it in the singleton
    void octaveDown()
    {
        writeToLog("Current Octave: " + OctaveSingleton.Instance.currentOctave.ToString(), true, false, false);

        if (OctaveSingleton.Instance.currentOctave > minOctave)
        {
            OctaveSingleton.Instance.currentOctave--;
            OctaveText.text = OctaveSingleton.Instance.currentOctave.ToString();
        }
    }

    //increments the current octave and stores it in the singleton
    void octaveUp()
    {
        writeToLog("Current Octave: " + OctaveSingleton.Instance.currentOctave.ToString(), true, false, false);

        if (OctaveSingleton.Instance.currentOctave < maxOctave)
        {
            OctaveSingleton.Instance.currentOctave++;
            OctaveText.text = OctaveSingleton.Instance.currentOctave.ToString();
        }
    }

    private void writeToLog(string message)
    {
        writeToLog(message, true, true, true);
    }

    // outputs logging to a hardcoded text file location
    private void writeToLog(string message, bool time, bool world, bool screen)
    {
        string output = "";
        if (time)
        {
            output = "[" + timeStamp + "]";
        }
        output = output + " " + message;
        if (world)
        {
            output = output + " - World gaze " + worldGaze;
        }
        if (screen)
        {
            output = output + " - Screen gaze " + screenGaze;
        }

        StreamWriter writer = new StreamWriter(logPath, true);

        writer.WriteLine(output);
        writer.Close();
    }
}