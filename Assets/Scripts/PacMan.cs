using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PacMan : MonoBehaviour {

	public GameObject Ground;
	public MazeGenerator generator;

	public Button LeftButton;
	public Button RightButton;

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
					cube.transform.position = new Vector3(i - size/2, 1, j - size/2);  
					cube.transform.parent = Ground.transform;
					cube.transform.localScale.Set(1/size,1/size,1);
//					cube.AddComponent<Rigidbody>();

				}
//				if (Map[i, j] == 5)
//				{
//					GameObject pacman = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//					pacman.transform.position = new Vector3(i, 0, j);
//				}
			}
		}


		// init buttons
		Button btn = LeftButton.GetComponent<Button>();
		btn.onClick.AddListener(TurenLeft);

		btn = RightButton.GetComponent<Button>();
		btn.onClick.AddListener(TurenRight);

	}

	// Update is called once per frame
	void Update () {
		// move forward
		float maxDist = 4f;
		float dist = Vector3.Distance(this.transform.position, this.transform.parent.transform.position);
		Ground.transform.Translate(new Vector3(0,0, Time.fixedDeltaTime * speed * (1-dist/maxDist) * -1), Space.World);
		
		this.GetComponent<Rigidbody>().AddForce((this.transform.parent.transform.position - this.transform.position) * 3);
		Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), 100f * Time.deltaTime * Input.GetAxis ("Horizontal"));

		if (Input.touchCount > 0)
		{
			Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), 100f * Time.deltaTime * Input.touches[0].deltaPosition.x);
		}

		this.transform.rotation = this.transform.parent.transform.rotation;
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
