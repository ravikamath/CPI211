using UnityEngine;
using System.Collections;

public class PatternGenerator : MonoBehaviour {
	
	public GameObject block;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			DestroyPattern();
			switch (Random.Range(0,5)) {
			case 0: MakeGrid(); break;
			case 1: MakeTriangle1(); break;
			case 2: MakeTriangle2(); break;
			case 3: MakeDiamond(); break;
			case 4: MakeChecker(); break;
			}
		}
	}
	
	void MakeGrid() {
		for(int i = 0; i < 10; i = i+1)
			for(int j = 0; j < 10; j = j + 1)
				Instantiate(block,
					transform.position + new Vector3(i*5,0, j*5),
					block.transform.rotation);
	}
	
	void MakeTriangle1() {
		for(int i = 0; i < 10; i = i+1)
			for(int j = i; j < 10; j = j + 1)
				Instantiate(block,
					transform.position + new Vector3(i*5,0, j*5),
					block.transform.rotation);
	}
	
	void MakeTriangle2() {
		for(int i = 0; i < 10; i = i+1)
			for(int j = i; j < 10-i; j = j + 1)
				Instantiate(block,
					transform.position + new Vector3(i*5,0, j*5),
					block.transform.rotation);
	}
	
	void MakeDiamond() {
		for(int i = 0; i < 10; i = i+1)
			for(int j = i; j < 10-i; j = j + 1)
			{
				Instantiate(block,
					transform.position + new Vector3(i*5 + 27.5f,0, j*5),
					block.transform.rotation);
				Instantiate(block,
					transform.position + new Vector3(-i*5 + 22.5f,0, j*5),
					block.transform.rotation);
			}
	}
	
	void MakeChecker() {
		for(int i = 0; i < 10; i = i+1)
			for(int j = 0; j < 10; j = j + 1)
				if((i*j) % 2 != 0)
				Instantiate(block,
					transform.position + new Vector3(i*5,0, j*5),
					block.transform.rotation);
	}
	
	void DestroyPattern() {
		GameObject[] blocks = GameObject.FindGameObjectsWithTag("Brick");
		foreach(GameObject b in blocks)
			Destroy(b);
	}
}
