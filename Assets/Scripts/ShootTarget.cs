using UnityEngine;
using System.Collections;

public class ShootTarget : MonoBehaviour {
	public Rigidbody bullet;
	public float speed;
	public Camera firstPersonCamera;
	public GUITexture cursor;
	
	public AudioClip rightClip;
	public AudioClip wrongClip;

	void Update () {
		if(GameObject.FindGameObjectsWithTag("Target").Length == 0)
			NextTarget();
		
		cursor.color = Color.white;
		Vector3 direction = 
			firstPersonCamera.ScreenToWorldPoint(
				Input.mousePosition + Vector3.forward) - 
				firstPersonCamera.transform.position;
		direction.Normalize(); // Make it length 1
		RaycastHit hitInfo;
		if (Physics.Raycast(firstPersonCamera.transform.position,
				direction, out hitInfo, firstPersonCamera.farClipPlane)) {
			if(hitInfo.collider.tag == "Target") {
				// change the mouse color!
				cursor.color = Color.green;
				if((hitInfo.collider.transform.position - 
					firstPersonCamera.transform.position).magnitude < 10)
					cursor.color = Color.yellow;
				if(Input.GetButtonDown("Fire1")) {
					GameObject bulletInstance = Instantiate(
						bullet.gameObject,
						firstPersonCamera.transform.position,
						bullet.transform.rotation) as GameObject;
					bulletInstance.rigidbody.velocity = direction * speed;
					audio.PlayOneShot(rightClip);
				}
			}
			else {
				cursor.color = Color.red;
				if(Input.GetButtonDown("Fire1"))
					audio.PlayOneShot(wrongClip);
			}
		}
	}
	
	void NextTarget() {
		GameObject[] relics =
			GameObject.FindGameObjectsWithTag("Brick");
		GameObject nextTarget = relics[Random.Range(0, relics.Length)];
		nextTarget.tag = "Target";
	}
}
