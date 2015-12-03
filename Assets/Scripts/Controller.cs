using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	public static int health = 100;
	public static int lives = 3;
	public static int score = 0;
	public static string name = "Unknown";

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}
}
