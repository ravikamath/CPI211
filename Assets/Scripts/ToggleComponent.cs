using UnityEngine;
using System.Collections;

public class ToggleComponent : MonoBehaviour {
	public GameObject platform;
	public Transform targetA;
	public Transform targetB;
	
	void OnMouseDown() {
		PlatformMover component = platform.GetComponent<PlatformMover>();
		if(component == null){
			// Component does not exist, add it!
			component = platform.AddComponent<PlatformMover>();
			component.targetA = targetA;
			component.targetB = targetB;
		}
		else // If component exists, just play with it
			component.enabled = !component.enabled;
	}
}
