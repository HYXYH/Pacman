using UnityEngine;
using System.Collections;

public class PacMan : MonoBehaviour {

	public GameObject Ground;
	CreateMaze generator = new CreateMaze();

	public int height = 28;
	public int width = 28;
	public int[,] Map;

	void Start () {
	
		Map = generator.generateMap();

		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				if (Map[i,j] == 1)
				{
					
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.transform.position = new Vector3(i - height/2, 1, j - width/2);  
					cube.transform.parent = Ground.transform;
					cube.transform.localScale.Set(1/width,1/height,1);

				}
//				if (Map[i, j] == 5)
//				{
//					GameObject pacman = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//					pacman.transform.position = new Vector3(i, 0, j);
//				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
