using UnityEngine;
using System.Collections;

public class Drawer : MonoBehaviour {

	public bool locked = true;
	private int index;
	public Animation targetAnimation;
	public string[] clips;
	public AudioClip[] audioClips;
	public AudioClip lockedClip;
	
	void OnMouseDown()
	{
		if(locked)
		{
			audio.PlayOneShot(lockedClip);
		}
		else if(!targetAnimation.isPlaying)
		{
			targetAnimation.Play(clips[index]);
			audio.PlayOneShot(audioClips[index]);
			index = (index + 1) % clips.Length;
		}
	}
}
