using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {


	public GameObject Ground;

	public float speed = 1f;
	public float angleSpeed = 100f;

	void Start () {
		float ran = Random.Range(0, 3);
		moveTime = Time.time + ran;

		Ground = this.transform.parent.gameObject;
	}

	float moveTime;
	float angle = 0;
	int direction = 0;
	// Update is called once per frame
	void Update () {
		// move forward
		if(direction == 0)
			this.GetComponent<Rigidbody>().AddForce((this.transform.forward) * speed, ForceMode.Impulse);
		this.GetComponent<Rigidbody>().AddForce(-9.8f * Vector3.Cross(Ground.transform.forward, Ground.transform.right).normalized , ForceMode.Force);


//		if( Time.time >= moveTime && direction == 0){
//			moveTime = Time.time + Random.Range(0, 5);
//			direction = 1;
//			direction -= 2 * Random.Range(0, 10) % 2;
//			angle = 90;
//		}
//
		transform.RotateAround(this.transform.position, Ground.transform.up, angleSpeed * Time.deltaTime * direction);
		angle -= angleSpeed * Time.deltaTime;
		if(angle <= 10)
		{
			transform.RotateAround(this.transform.position, Ground.transform.up, angle * direction);
			direction = 0;
		}

		if( Time.time >= moveTime  && direction == 0){
			moveTime = Time.time + Random.Range(0, 3);
			int id = getBestDirectionId();
			if(id==3){
				angle = 90;
				direction = -1;
			}
			else{
				angle = 90 * id;
				direction = 1;
				}
			}
	}
		
	int getBestDirectionId()
	{
		Vector3 best = Vector3.zero;
		int bestId = 0;
		for(int i = 0; i < 4; i++)
		{
			RaycastHit hit;
			Vector3 dir = transform.forward;
			dir = Quaternion.AngleAxis(i * 90, transform.up) * dir;

			if (Physics.Raycast(transform.position, dir, out hit))
			{
				if(hit.collider.tag == "Player")
					return i;
				
				if(Vector3.Distance(hit.point, transform.position) > best.magnitude){
					best = dir;
					bestId = i;
				}
			}
		}
		return bestId;
	}

	void OnCollisionEnter(Collision collision)
	{
		moveTime = 0f;
	}

}
