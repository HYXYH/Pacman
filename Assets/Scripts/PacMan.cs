using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PacMan : MonoBehaviour {

	public GameObject Ground;
	public MazeGenerator generator;

	public Button LeftButton;
	public Button RightButton;

	public Material mat;
	public float speed = 1f;

	int move = 0;

	void Start () {

		int size = generator.getSize();
	
		int[,] Map = generator.Generate();

		for (int i = 0; i < size+1; i++)
		{
			for (int j = 0; j < size+1; j++)
			{
				if (Map[i,j] == 1)
				{
					
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

					cube.GetComponent<MeshRenderer>().material = mat;
					cube.transform.position = new Vector3(i - size/2, 1, j - size/2);  
					cube.transform.parent = Ground.transform;
//					cube.transform.localScale.Set(1/size,1/size,1);
//					cube.transform.localScale = new Vector3(1f, 1f, 1f);
//					cube.AddComponent<Rigidbody>();

				}
				if (Map[i, j] == 0)
				{
					//GameObject food = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					//food.transform.position = new Vector3(i - size/2, 1, j - size/2);  
					//food.transform.parent = Ground.transform;
//					food.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
				}
			}
		}
//		transform.localScale.Set(1/size,1/size,1/size);

		// init buttons
//		Button btn = LeftButton.GetComponent<Button>();
//		btn.onClick.AddListener(TurenLeft);
//
//		btn = RightButton.GetComponent<Button>();
//		btn.onClick.AddListener(TurenRight);

	}

	float angle = 0;
	int direction = 0;
	// Update is called once per frame
	void Update () {
		// move forward
		float maxDist = 4f;
		float dist = Vector3.Distance(this.transform.position, this.transform.parent.transform.position);
//		Ground.transform.Translate(new Vector3(0,0, Time.fixedDeltaTime * speed * (1-dist/maxDist) * -1), Space.World);

		//force
		this.GetComponent<Rigidbody>().AddForce((this.transform.parent.transform.position - this.transform.position) * 3);

//		Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), 100f * Time.deltaTime * Input.GetAxis ("Horizontal"));
//
//		if (Input.touchCount > 0)
//		{
//			Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), 100f * Time.deltaTime * Input.touches[0].deltaPosition.x);
//		}
//
		this.transform.rotation = this.transform.parent.transform.rotation;

		if( Input.GetKeyDown( KeyCode.RightArrow ) && direction == 0){
			direction++;
			angle = 90;
		}
		if( Input.GetKeyDown( KeyCode.LeftArrow ) && direction == 0){
			direction--;
			angle = 90;
		}

//		Ground.transform.rotation = Quaternion.Lerp(Ground.transform.rotation, Quaternion.Euler(0,timesHit*90,0), Time.deltaTime*speed);
		Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), 100f * Time.deltaTime * direction);
		angle -= 100f * Time.deltaTime;
		if(angle <= 3)
		{
			Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), angle * direction);
			direction = 0;
		}

	}


	public void TurenLeft()
	{
		Debug.Log ("Left!");
//		Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), 90);
	}

	public void TurenRight()
	{
		Debug.Log ("Right!");
//		Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), -90);
		move = -1;
	}

}
