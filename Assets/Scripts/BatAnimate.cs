using UnityEngine;
using System.Collections;

public class BatAnimate : MonoBehaviour {

	int clipIndex = 0;
	public Animation targetAnimation;
	public string[] animations;
	
	void OnMouseDown()
	{
		if(!targetAnimation.isPlaying)
		{	
			targetAnimation.Play(animations[clipIndex]);
			clipIndex = (clipIndex + 1) % animations.Length;
		}
	}
}
