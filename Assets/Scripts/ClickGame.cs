using UnityEngine;
using System.Collections;

public class ClickGame : MonoBehaviour {
	
	public GUITexture cursor;
	public GUITexture[] score;
	public GUIText timer;
	public Camera firstPersonCamera;
	public GameObject destroyWall;
	
	
	public GameObject[] relics;
	public GameObject nextTarget;
	public int relicsCollected = 0;
	int relicsToCollect = 5;
	
	float totalTime = 30;
	float startTime;
	
	void Start () {
		relics = GameObject.FindGameObjectsWithTag("Brick");
		startTime = Time.time;
		for(int i = 0; i < score.Length; i++)
			score[i].enabled = false;
		SetNextTarget();
	}
	
	void Update () {
		cursor.color = Color.white;
		bool canCollect = false;
		RaycastHit info;
		if(nextTarget.collider.Raycast(
			firstPersonCamera.ScreenPointToRay(Input.mousePosition),
			out info, firstPersonCamera.farClipPlane)) {
			cursor.color = Color.red;
			
			if((nextTarget.transform.position - 
				firstPersonCamera.transform.position).magnitude < 5) {
				cursor.color = Color.green;
				canCollect = true;
			}
		}
		
		if(Input.GetButtonDown("Fire1")) {
			if(canCollect) {
				score[relicsCollected].enabled = true;
				relicsCollected++;
				if(relicsCollected >= relicsToCollect) {
					Destroy (destroyWall);
					Destroy (this);
					cursor.color = Color.white;
				}
			}
			else {
				relicsCollected = 0;
				startTime = Time.time;
				for(int i = 0; i < score.Length; i++)
					score[i].enabled = false;
			}
			SetNextTarget();
		}
		
		int timeRemaining = (int)(totalTime + startTime - Time.time + 0.5f);
		timer.text = timeRemaining / 60 + ":" + (timeRemaining % 60).ToString("D2");
		if(timeRemaining <= 0) {
			relicsCollected = 0;
			startTime = Time.time;
			for(int i = 0; i < score.Length; i++)
					score[i].enabled = false;
			SetNextTarget();
		}
	}
	
	void SetNextTarget() {
		nextTarget = relics[Random.Range(0, relics.Length)];
	}
}
