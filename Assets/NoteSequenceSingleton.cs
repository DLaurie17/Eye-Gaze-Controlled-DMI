using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Singleton used as a global variable to store and access the note the user needs to play next for the current task.
public class NoteSequenceSingleton : MonoBehaviour
{
    public static NoteSequenceSingleton Instance { get; private set; }

    public string[] noteSequence;
    public int noteSequencePosition;

    public Text NextNoteText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            noteSequence = new string[] { "" };
            noteSequencePosition = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
