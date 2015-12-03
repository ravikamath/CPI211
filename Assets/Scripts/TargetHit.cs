using UnityEngine;
using System.Collections;

public class TargetHit : MonoBehaviour {
	
	public AudioClip clip;
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Bullet") {
			Destroy(collision.gameObject);
		gameObject.tag = "Brick";
		audio.PlayOneShot(clip, 10);
		}
	}
}
