using UnityEngine;
using System.Collections;

public class CreateWall : MonoBehaviour {
	
	public GameObject brick;
	public int width = 10;
	public int height = 5;
	
	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < width; i = i + 1)
			for(int j = 0; j < height; j = j + 1)
				Instantiate(brick, 
					transform.position +new Vector3 (i*2,j,0), 
					brick.transform.rotation);
	}
}
