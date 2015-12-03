using UnityEngine;
using System.Collections;

public class ModifyColor : MonoBehaviour {
	
	public GameObject platform;
	
	void OnMouseDown() {
		platform.SendMessage("ChangeColor");
		// an alternative would be:
		// platform.GetComponent<ColorChanger>().ChangeColor();
	}
}
