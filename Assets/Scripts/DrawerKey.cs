using UnityEngine;
using System.Collections;

public class DrawerKey : Item {

	public override void Consume ()
	{
		target.gameObject.GetComponent<Drawer>().locked = false;
	}
}
