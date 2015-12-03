using UnityEngine;
using System.Collections;

public class ElevatorMover : MonoBehaviour {
	public Transform targetA;
	public Transform targetB;
	public float speed = 0.5f;
	public float t = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
		t = (t + speed * Time.deltaTime);
		if(t < 0) t = 0;
		if(t > Mathf.PI) t = Mathf.PI;
		float cosT = Mathf.Cos(t)/2 + 0.5f;
		transform.position = 
				targetA.position * (1-cosT) +
			targetB.position * cosT;
	}
}
