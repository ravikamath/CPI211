using UnityEngine;
using System.Collections;

public class Item : Interactor {

	public Collider target;
	
	public override bool Use()
	{
		RaycastHit info;
		if(target.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
			out info, Camera.main.farClipPlane))
		{
			Consume ();
			Destroy (gameObject);
			return true;
		}
		return false;
	}
	
	public virtual void Consume()
	{
	}
}
