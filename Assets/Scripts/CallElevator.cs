using UnityEngine;
using System.Collections;

public class CallElevator : MonoBehaviour {

	public GameObject platform;
	public float speed = 0.5f;
	
	void OnMouseDown() {
		platform.GetComponent<ElevatorMover>().speed = speed;
	}
}
