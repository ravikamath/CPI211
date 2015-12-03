using UnityEngine;
using System.Collections;

public class CursorColorChange : MonoBehaviour {
	
	void OnMouseEnter() {
		GameObject.FindGameObjectWithTag("Cursor").
			guiTexture.color = Color.green;
	}
	
	void OnMouseExit() {
		GameObject.FindGameObjectWithTag("Cursor").
			guiTexture.color = Color.white;
	}
}
