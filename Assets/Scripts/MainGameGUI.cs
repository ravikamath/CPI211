using UnityEngine;
using System.Collections;

public class MainGameGUI : MonoBehaviour {

	void OnGUI() {
		GUI.Label(new Rect(50,50,200,20), Controller.name);
	}
}
