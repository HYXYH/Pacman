using UnityEngine;
using System.Collections;

public class PacMan : MonoBehaviour {

	public GameObject Ground;
	public MazeGenerator generator;

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
