using UnityEngine;
using System.Collections;
using System.Timers;
using System;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {


	public Camera cameraMain;

	void Start(){

	}


    // Update is called once per frame
    void Update () {

		RaycastHit hit;
		Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
		if(Input.touchCount > 0)
		{
			ray = cameraMain.ScreenPointToRay(Input.GetTouch(0).position);
		}

		if (Physics.Raycast(ray, out hit)) {
			Transform objectHit = hit.transform;
			if(objectHit.tag == "menu")
				{
				SceneManager.LoadScene("Pacman");
				}

				// Do something with the object that was hit by the raycast.
			}
	}
}
