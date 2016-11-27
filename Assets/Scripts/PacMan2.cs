using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PacMan2 : MonoBehaviour {


	public GameObject foodExample;
	public GameObject wallExample;
	public GameObject monsterExample;
	public GameObject Ground;
	MazeGenerator generator;

	public Text scoreText;
	public Button LeftButton;
	public Button RightButton;
	public Button ResetButton;

	public int score = 0;
	public float speed = 1f;
	public float angleSpeed = 100f;

	void Start () {

		generator = this.GetComponent<MazeGenerator>();

		int size = generator.getSize();

		int[,] Map = generator.Generate();

		for (int i = 0; i < size+1; i++)
		{
			for (int j = 0; j < size+1; j++)
			{
				if (Map[i,j] == 1)
				{

					GameObject cube = Instantiate(wallExample);
					cube.transform.position = new Vector3(i - size/2, 1, j - size/2);  
					cube.transform.parent = Ground.transform;
					cube.transform.localScale.Set(1/size,1/size,1);
					//					cube.AddComponent<Rigidbody>();

				}
				else if (Map[i, j] == 0)
				{
					GameObject food = Instantiate(foodExample);
					food.transform.position = new Vector3(i - size/2, 1, j - size/2);  
					food.transform.parent = Ground.transform;
					food.transform.localScale.Set(1/size,1/size,1);
				}
				else if (Map[i, j] == 4)
				{
					GameObject monster = Instantiate(monsterExample);
//					monster.transform.position = Ground.transform.position + Ground.transform.up + Ground.transform.forward * (i - size/2) + Ground.transform.right * (j - size/2);
					monster.transform.position = new Vector3(i - size/2, 1, j - size/2);  
					monster.transform.parent = Ground.transform;
					monster.transform.localScale.Set(1/size,1/size,1);
				}
			}
		}
		//		transform.localScale.Set(1/size,1/size,1/size);

		// init buttons
		Button btn = LeftButton.GetComponent<Button>();
		btn.onClick.AddListener(TurnLeft);
		
		btn = RightButton.GetComponent<Button>();
		btn.onClick.AddListener(TurnRight);

		btn = ResetButton.GetComponent<Button>();
		btn.onClick.AddListener(Reset);

	}

	float angle = 0;
	int direction = 0;
	// Update is called once per frame
	void Update () {
		// move forward
		this.GetComponent<Rigidbody>().AddForce((this.transform.forward) * speed, ForceMode.Impulse);
		this.GetComponent<Rigidbody>().AddForce(-9.8f * Vector3.Cross(Ground.transform.forward, Ground.transform.right).normalized , ForceMode.Force);



		if( Input.GetKeyDown( KeyCode.RightArrow ) && direction == 0){
			direction++;
			angle = 90;
		}
		if( Input.GetKeyDown( KeyCode.LeftArrow ) && direction == 0){
			direction--;
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


	public void TurnLeft()
	{
		Debug.Log ("Left!");
		//		Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), 90);
		if( direction == 0){
			direction--;
			angle = 90;
		}
	}

	public void TurnRight()
	{
		Debug.Log ("Right!");
		//		Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), -90);
		if( direction == 0){
			direction++;
			angle = 90;
		}
	}

	public void Reset()
	{
		Debug.Log ("Reset!");
		//		Ground.transform.RotateAround(this.transform.position, new Vector3(0,1,0), -90);
		this.transform.position = Ground.transform.position + Ground.transform.up;
	}

	public void addScore()
	{
		score++;
		scoreText.text = score.ToString();
	}
}
