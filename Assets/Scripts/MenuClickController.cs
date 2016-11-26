using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MenuClickController : MonoBehaviour {
	private int counter = 0;

	// Use this for initialization
	void Start () {
		Debug.Log ("kek1");
		Physics.queriesHitTriggers = true;
	}
	
	// Update is called once per frame
	void Update () {
		counter ++;
		if (counter < 40)
			transform.Translate(Vector3.up * Time.deltaTime);
		if (Input.GetButtonDown("Fire1")) {
			SceneManager.LoadScene("Pacman");
		}
	}

//	void onMouseDown() {
////		Destroy (this.gameObject);
//		Debug.Log ("kek clicked");
//		SceneManager.LoadScene("Pacman");
//
//	}
}
