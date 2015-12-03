using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.showCursor = false; // show hide cursor, but doesn't
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = Input.mousePosition;
		//guiTexture.pixelInset = 
		//	new Rect(mousePosition.x-8,
		//		mousePosition.y-24,
		//		guiTexture.pixelInset.width,
		//		guiTexture.pixelInset.height);
		transform.position = new Vector3(
			mousePosition.x / Screen.width,
			mousePosition.y / Screen.height,
			0);
	}
}
