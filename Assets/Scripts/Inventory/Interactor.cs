using UnityEngine;
using System.Collections;

public class Interactor : MonoBehaviour {
	
	public Texture2D inventoryIcon;
	public GameObject worldIcon;
	protected bool isDragging = false;
	
	void OnMouseDown()
	{
		isDragging = false;
	}
	
	public virtual void OnMouseUp()
	{
		if(!isDragging)
		{
			GameObject.FindGameObjectWithTag("GameController").
				GetComponent<InventoryManager>().Interact(this);
		}
		else
		{
			GameObject.FindGameObjectWithTag("GameController").
				GetComponent<InventoryManager>().Interact(this);
		}
	}
	
	public virtual bool Use()
	{
		Destroy (gameObject);
		return true;
	}
}
