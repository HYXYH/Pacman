using UnityEngine;
using System.Collections;
using System.Timers;
using System;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    private static System.Timers.Timer aTimer;

    // Use this for initialization
    void Start () {
        SetTimer();
    }

    private static void SetTimer()
    {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(2000);
        
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
       // aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    private static void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        SceneManager.LoadScene("Pacman");
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0, 0);
    }





    // Update is called once per frame
    void Update () {
	
	}
}
