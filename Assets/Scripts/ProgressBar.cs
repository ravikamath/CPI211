using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	public float totalTime;
	public float currentTime;
	public float startTime;
	
	public Texture2D texture;
	
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime = startTime + totalTime - Time.time;
	}
	
	void OnGUI() {
		GUI.color = Color.grey;
		GUI.DrawTexture(new Rect(0,0,totalTime*10,100), texture);
		GUI.color = Color.red;
		GUI.BeginGroup(new Rect(0,0,currentTime*10,100));
		GUI.DrawTexture(new Rect(0,0,totalTime*10,100), texture);
		GUI.EndGroup();
	}
}
