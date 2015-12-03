using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	public GUISkin skin;
	public int itemSize = 64;
	private int page = 0;
	private List<Interactor> items;
	private Interactor _selectedItem;
	public Interactor selectedItem
	{
		get { return _selectedItem;}
		set
		{
			if(_selectedItem != null)
			{
				_selectedItem.worldIcon.SetActive(false);
				_selectedItem = null;
				
			}
			_selectedItem = value;
			if(_selectedItem != null)
				_selectedItem.worldIcon.SetActive(true);
		}
	}

	// Use this for initialization
	void Start ()
	{
		items = new List<Interactor>();
		selectedItem = null;
	}
	
	void Update()
	{
		if(selectedItem != null && selectedItem as Item)
		{
			selectedItem.worldIcon.transform.position =
				Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(1);
			if(Input.GetMouseButtonDown(0))
				UseItem(selectedItem);
			else if(Input.GetMouseButtonDown(1))
				selectedItem = null;
		}
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		int itemsPerPage = Screen.width / itemSize - 1;
		GUI.BeginGroup(new Rect(0,Screen.height - itemSize,Screen.width, itemSize));
		float offset = (Screen.width - itemsPerPage * itemSize)/2;
		if(GUI.Button (new Rect(0,0,offset,itemSize), "<"))
			page = Mathf.Max(0, page - 1);
		for(int i = 0; i < itemsPerPage; i++)
		{
			if(page * itemsPerPage + i < items.Count)
			{
				if(GUI.Button (new Rect(offset+i*itemSize, 0, itemSize, itemSize),
					items[page * itemsPerPage + i].inventoryIcon))
				{
					selectedItem = items[page * itemsPerPage + i];
				}
			}
			else
				GUI.Button (new Rect(offset+i*itemSize, 0, itemSize, itemSize),
					"");
				
		}
		if(GUI.Button (new Rect(Screen.width - offset,0, offset,itemSize), ">"))
			page = Mathf.Min(items.Count / itemsPerPage, page + 1);
		GUI.EndGroup();
	}
	
	public void Interact(Interactor item)
	{
		if(items.Contains(item))
			return;
		items.Add (item);
		if(item.worldIcon == null)
		{
			item.worldIcon = item.gameObject;
			item.worldIcon.transform.localScale *= 0.2f;
			
		}
		item.gameObject.SetActive(false);
	}
	
	public void UseItem(Interactor item)
	{
		if(item.Use ())
		{
			items.Remove (item);
			selectedItem = null;
		}
	}
}
