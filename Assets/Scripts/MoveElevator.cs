using UnityEngine;
using System.Collections;

public class MoveElevator : MonoBehaviour {

	public GameObject platform;
	
	void OnMouseDown() {
		platform.GetComponent<ElevatorMover>().speed *= -1;
	}
}
