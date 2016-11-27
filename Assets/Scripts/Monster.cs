using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {


	public GameObject Ground;

	public float speed = 1f;
	public float angleSpeed = 100f;

	void Start () {
		float ran = Random.Range(0, 5);
		moveTime = Time.time + ran;

		Ground = this.transform.parent.gameObject;
	}

	float moveTime;
	float angle = 0;
	int direction = 0;
	// Update is called once per frame
	void Update () {
		// move forward
		this.GetComponent<Rigidbody>().AddForce((this.transform.forward) * speed, ForceMode.Impulse);
		this.GetComponent<Rigidbody>().AddForce(-9.8f * Vector3.Cross(Ground.transform.forward, Ground.transform.right).normalized , ForceMode.Force);


		if( Time.time >= moveTime && direction == 0){
			moveTime = Time.time + Random.Range(0, 5);
			direction = 1;
			direction -= 2 * Random.Range(0, 10) % 2;
			angle = 90;
		}

		transform.RotateAround(this.transform.position, Ground.transform.up, angleSpeed * Time.deltaTime * direction);
		angle -= angleSpeed * Time.deltaTime;
		if(angle <= 3)
		{
			transform.RotateAround(this.transform.position, Ground.transform.up, angle * direction);
			direction = 0;
		}
	}
		
}
