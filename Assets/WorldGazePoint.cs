using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

// Singleton used for storing the users gaze captured by the eye tracker as world coordinates.
public class WorldGazePoint : MonoBehaviour
{
    Vector3 gazeVector;
    GazePoint gazePoint;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Constantly updates the singleton with the current gaze point using world coordinates.
    void Update()
    {
        gazePoint = TobiiAPI.GetGazePoint();
        float gazeX = gazePoint.Screen.x;
        float gazeY = gazePoint.Screen.y;

        gazeVector.Set(gazeX, gazeY, 0);

        WorldGazePointSingleton.Instance.screenGazeVector = gazeVector;

        // Convert screen coordinates to world coordinates.
        gazeVector = cam.ScreenToWorldPoint(gazeVector);
        //set depth to 0 as notes are at z = 0 and the camera is at z = -10.
        gazeVector.Set(gazeVector.x, gazeVector.y, 0);

        WorldGazePointSingleton.Instance.worldGazeVector = gazeVector;
        
    }
}
