using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	
	public GUISkin skin;
	public Texture2D background;
	
	void OnGUI() {
		GUI.skin = skin;
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),background);
			
		GUI.BeginGroup(new Rect(Time.time,Time.time, 400,600));
			if(GUI.Button(new Rect(50,50,200,40), "Play")){
				//Application.LoadLevel("Lab 5");
				Application.LoadLevel(Application.loadedLevel+1);
			}
			if(GUI.Button(new Rect(50,100,200,40), "Controls")){
			}
			if(GUI.Button(new Rect(50,150,200,40), "Quit"))
				Application.Quit ();
			Controller.name = 
				GUI.TextField(new Rect(50,200,200,40), Controller.name);
		GUI.EndGroup();
	}
}
