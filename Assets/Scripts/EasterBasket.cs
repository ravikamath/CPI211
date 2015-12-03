using UnityEngine;
using System.Collections;

public class EasterBasket : MonoBehaviour {
	
	public GameObject particles;
	
	void OnMouseDown()
	{
		EasterMiniGame component = gameObject.AddComponent<EasterMiniGame>();
		component.particles = particles;
		Destroy (this);
	}
}
