using System.Collections;
using UnityEngine;
using System.IO;
using System;

//Contains the main functionality of the eye gaze interaction with notes.
public class GazePlayNote  : MonoBehaviour
{
    AudioSource[] notes;
    CircleCollider2D circleCollider2D;
    Vector3 worldGaze;
    Vector3 screenGaze;
    private bool stoppingNote = false;
    private bool sustain = false;
    private bool playingNoteSelectionArea = false;
    private bool changingOctave = false;
    string logPath = "Assets/Logs/log.txt";
    string objectName;
    string noteName;
    string timeStamp;
    GameObject highlightObject;
    SpriteRenderer highlightObjectRenderer;
    private bool taskRunning = false;

    void Start()
    {
        timeStamp = DateTime.UtcNow.ToString() + ":" + DateTime.UtcNow.Millisecond.ToString();
        writeToLog("GazPlayNote.cs started");
        notes = GetComponents<AudioSource>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        objectName = gameObject.name.ToString();
        noteName = objectName.Remove(0, 4);
        highlightObject = GameObject.Find("DMI_Highlight");
        highlightObjectRenderer = highlightObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        setNoteSequence();
        StartCoroutine(SustainNotes());

        //Comment out the following eye gaze interactions that you don't want to use:

        //playNoteSwitches(); // eye gaze with a switch
        playNoteSelectionArea(); // eye gaze without a switch
        //playNoteSelectionAreaWithKeyPresses(); // eye gaze with a switch to repeat notes
    }


    // for storing and triggering each note sequence for each task used in experiments.
    private void setNoteSequence()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            string[] sequence = new string[] { "0 D", "0 C", "0 F", "0 D", "0 D#", "0 E", "0 E", "0 D", "0 E", "0 C#",
                "0 C", "0 F", "0 F", "0 E", "0 F", "0 C#", "0 D#", "0 D#", "0 C#", "0 D", "0 E", "0 D#", "0 C", "0 D",
                "0 C", "0 D", "0 F", "0 C", "0 C", "0 D" };
            NoteSequenceSingleton.Instance.noteSequence = sequence;
            NoteSequenceSingleton.Instance.NextNoteText.text = sequence[0].ToString().Split(' ')[0];
            NoteSequenceSingleton.Instance.noteSequencePosition = 0;
            highlightObjectRenderer.enabled = true;
            highlightObject.transform.position = GameObject.Find("DMI_" + sequence[0].Split(' ')[1]).transform.position;
            MistakeCounterSingleton.Instance.mistakeCounter = 0;
            writeToLog("TASK 1 STARTED", true, false, false);
            taskRunning = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            string[] sequence = new string[] { "0 C", "0 B", "0 D", "0 A", "0 G", "0 E", "0 D", "0 A#", "0 B", "0 D",
                "0 F", "0 A", "0 G#", "0 D#", "0 G", "0 E", "0 F#", "0 C", "0 E", "0 D", "0 G", "0 G", "0 E", "0 C#",
                "0 C", "0 C", "0 G", "0 E", "0 B", "0 F" };
            NoteSequenceSingleton.Instance.noteSequence = sequence;
            NoteSequenceSingleton.Instance.NextNoteText.text = sequence[0].ToString().Split(' ')[0];
            NoteSequenceSingleton.Instance.noteSequencePosition = 0;
            highlightObjectRenderer.enabled = true;
            highlightObject.transform.position = GameObject.Find("DMI_" + sequence[0].Split(' ')[1]).transform.position;
            MistakeCounterSingleton.Instance.mistakeCounter = 0;
            writeToLog("TASK 2 STARTED", true, false, false);
            taskRunning = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            string[] sequence = new string[] { "-2 C", "0 B", "1 D", "-1 A", "-1 G", "1 E", "0 D", "-2 A#", "-1 B", "0 D",
                "-1 F", "-1 A", "-2 G#", "0 D#", "-1 G", "-1 E", "2 F#", "2 C", "1 E", "-1 D", "-2 G", "2 G", "0 E", "1 C#",
                "-2 C", "2 C", "0 G", "-1 E", "1 B", "2 F" };
            NoteSequenceSingleton.Instance.noteSequence = sequence;
            NoteSequenceSingleton.Instance.NextNoteText.text = sequence[0].ToString().Split(' ')[0];
            NoteSequenceSingleton.Instance.noteSequencePosition = 0;
            highlightObjectRenderer.enabled = true;
            highlightObject.transform.position = GameObject.Find("DMI_" + sequence[0].Split(' ')[1]).transform.position;
            MistakeCounterSingleton.Instance.mistakeCounter = 0;
            writeToLog("TASK 3 STARTED", true, false, false);
            taskRunning = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            string[] sequence = new string[] { "-2 C", "0 B", "1 D", "-1 A", "-1 G", "1 E", "0 D", "-2 A#", "-1 B", "0 D",
                "-1 F", "-1 A", "-2 G#", "0 D#", "-1 G", "-1 E", "2 F#", "2 C", "1 E", "-1 D", "-2 G", "2 G", "0 E", "1 C#",
                "-2 C", "2 C", "0 G", "-1 E", "1 B", "2 F", "2 D#","0 F#","-2 A#","-2 E","-2 D#","-2 B","-1 G","1 A","-1 B",
                "2 F","2 C#","-1 D","-2 D","0 D","-1 B","2 F#","0 B","2 F","-2 G","0 C#","2 E","-1 E","-2 E","2 A","2 D",
                "0 D#","2 G","-2 F","1 A","1 B" };
            NoteSequenceSingleton.Instance.noteSequence = sequence;
            NoteSequenceSingleton.Instance.NextNoteText.text = sequence[0].ToString().Split(' ')[0];
            NoteSequenceSingleton.Instance.noteSequencePosition = 0;
            highlightObjectRenderer.enabled = true;
            highlightObject.transform.position = GameObject.Find("DMI_" + sequence[0].Split(' ')[1]).transform.position;
            MistakeCounterSingleton.Instance.mistakeCounter = 0;
            writeToLog("TASK 4 STARTED", true, false, false);
            taskRunning = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            string[] sequence = new string[] { "" };
            NoteSequenceSingleton.Instance.noteSequence = sequence;
            NoteSequenceSingleton.Instance.NextNoteText.text = sequence[0];
            NoteSequenceSingleton.Instance.noteSequencePosition = 0;
            highlightObjectRenderer.enabled = false;
            MistakeCounterSingleton.Instance.mistakeCounter = 0;
            writeToLog("TASK CANCELLED", true, false, false);
            taskRunning = false;
        }
    }

    // compares the played note against the expected note in the sequence.
    private void checkNoteSequence()
    {
        string playedNote = OctaveSingleton.Instance.currentOctave.ToString() + " " + noteName;
        string[] noteSequence = NoteSequenceSingleton.Instance.noteSequence;
        int sequencePosition = NoteSequenceSingleton.Instance.noteSequencePosition;
        string expectedNote = noteSequence[sequencePosition];

        Debug.Log("Played: " + playedNote + ", Expected: " + expectedNote);
        
        if (expectedNote.Equals(playedNote))
        {
            writeToLog("SUCCESS - " + "Played: " + playedNote, true, false, false);
            sequencePosition++;
            if (sequencePosition > noteSequence.Length - 1)
            {
                NoteSequenceSingleton.Instance.NextNoteText.text = "END";
                highlightObjectRenderer.enabled = false;
                StartCoroutine(FlashNoteSuccess());
                NoteSequenceSingleton.Instance.noteSequencePosition = noteSequence.Length - 1;
                writeToLog("TASK ENDED", true, false, false);
                writeToLog("TASK MISTAKE COUNT '" + MistakeCounterSingleton.Instance.mistakeCounter.ToString() + "'", true, false, false);
            }
            else
            {
                NoteSequenceSingleton.Instance.NextNoteText.text = noteSequence[sequencePosition].ToString().Split(' ')[0];
                highlightObject.transform.position = GameObject.Find("DMI_" + noteSequence[sequencePosition].Split(' ')[1]).transform.position;
                StartCoroutine(FlashNoteSuccess());
                NoteSequenceSingleton.Instance.noteSequencePosition = sequencePosition;
            }
        }
        else
        {
            writeToLog("MISTAKE - " + "Played: " + playedNote + ", Expected: " + expectedNote, true, false, false);
            MistakeCounterSingleton.Instance.mistakeCounter++;
            StartCoroutine(FlashNoteFail());
        }
    }

    private void stopAllNotes()
    {
        foreach (AudioSource note in notes)
        {
            if (note.isPlaying)
            {
                note.Stop();
                writeToLog("Stopped note '" + objectName + "'", true, false, false);
            }
        }
        playingNoteSelectionArea = false;
    }

    // play the note if the user looks at a note, or presses the switch whilst they are already looking at a note (hybrid)
    private void playNoteSelectionAreaWithKeyPresses()
    {
        worldGaze = WorldGazePointSingleton.Instance.worldGazeVector;
        screenGaze = WorldGazePointSingleton.Instance.screenGazeVector;
        timeStamp = DateTime.UtcNow.ToString() + ":" + DateTime.UtcNow.Millisecond.ToString();

        
        if (!circleCollider2D.bounds.Contains(worldGaze) && playingNoteSelectionArea && changingOctave)
        {
            stopAllNotes();
            changingOctave = false;
        }       
        if (circleCollider2D.bounds.Contains(worldGaze) && !playingNoteSelectionArea && !changingOctave)
        {
            Debug.Log(changingOctave);
            notes[OctaveSingleton.Instance.currentOctave + 2].Play(0);
            if (taskRunning)
            {
                checkNoteSequence();
            }
            

            writeToLog("Triggered note '" + objectName + "'");
            playingNoteSelectionArea = true;
        }
        if (Input.GetKeyDown("d"))
        {
            if (circleCollider2D.bounds.Contains(worldGaze))
            {
                stopAllNotes();
                notes[OctaveSingleton.Instance.currentOctave + 2].Play(0);
                if (taskRunning)
                {
                    checkNoteSequence();
                }
                writeToLog("RETriggered note '" + objectName + "'");
                playingNoteSelectionArea = true;
            }
        }
        if (!circleCollider2D.bounds.Contains(worldGaze) && playingNoteSelectionArea)
        {
            stopAllNotes();
        }
        if (playingNoteSelectionArea && (Input.GetKeyDown("-") || Input.GetKeyDown("=")))
        {
            //stopAllNotes();
            changingOctave = true;
        }
    }

    // play the note if the user looks at the note
    private void playNoteSelectionArea()
    {
        worldGaze = WorldGazePointSingleton.Instance.worldGazeVector;
        screenGaze = WorldGazePointSingleton.Instance.screenGazeVector;
        timeStamp = DateTime.UtcNow.ToString() + ":" + DateTime.UtcNow.Millisecond.ToString();

        
        if (circleCollider2D.bounds.Contains(worldGaze) && !playingNoteSelectionArea)
        {
            notes[OctaveSingleton.Instance.currentOctave + 2].Play(0);
            if (taskRunning)
            {
                checkNoteSequence();
            }

            writeToLog("Triggered note '" + objectName + "'");
            playingNoteSelectionArea = true;
        }
        if (!circleCollider2D.bounds.Contains(worldGaze) && playingNoteSelectionArea)
        {
            foreach(AudioSource note in notes)
            {
                if (note.isPlaying)
                {
                    writeToLog("Stopped note '" + objectName + "'", true, false, false);
                    note.Stop();
                }
            }
            playingNoteSelectionArea = false;
        }
    }

    // Play a note only if the user presses the switch whilst looking at the note.
    private void playNoteSwitches()
    {
        if (Input.GetKeyDown("s"))
        {
            worldGaze = WorldGazePointSingleton.Instance.worldGazeVector;

            // If the gaze point is within the boundary of a note, play it.
            if (circleCollider2D.bounds.Contains(worldGaze))
            {
                notes[OctaveSingleton.Instance.currentOctave + 2].Play(0);
            }
            else
            {
                Debug.Log("Gaze point not in a note.");
            }
        }
        if (Input.GetKeyUp("d") && !sustain && !stoppingNote)
        {
            StartCoroutine(StopNote());
        }
    }

    // IEnumerator is used for concurrency
    private IEnumerator StopNote()
    {
        stoppingNote = true;
        yield return new WaitForSeconds(0.00f);
        notes[OctaveSingleton.Instance.currentOctave + 2].Stop();
        stoppingNote = false;
    }

    private IEnumerator SustainNotes()
    {
        if (Input.GetKeyDown("f"))
        {
            sustain = true;
        }
        if (Input.GetKeyUp("f"))
        {
            sustain = false;
        }
        yield return sustain;
    }

    private IEnumerator DoubleCheckNoteSelection()
    {
        yield return new WaitForSeconds(5.00f);
    }

    // note indicator feedback
    private IEnumerator FlashNoteSuccess()
    {
        highlightObjectRenderer.color = Color.green;
        NoteSequenceSingleton.Instance.NextNoteText.color = Color.green;
        yield return new WaitForSeconds(0.3f);
        NoteSequenceSingleton.Instance.NextNoteText.color = Color.white;
        highlightObjectRenderer.color = Color.white;
    }
    private IEnumerator FlashNoteFail()
    {
        highlightObjectRenderer.color = Color.red;
        NoteSequenceSingleton.Instance.NextNoteText.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        NoteSequenceSingleton.Instance.NextNoteText.color = Color.white;
        highlightObjectRenderer.color = Color.white;
    }

    private void writeToLog(string message)
    {
        writeToLog(message, true, true, true);
    }

    // used for logging information about the user's performance.
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
