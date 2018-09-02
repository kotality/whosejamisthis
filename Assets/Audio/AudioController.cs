using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {


	public AudioClip[] audioClp;
	AudioSource audioSrc;
	public bool RandomClip;
	public bool playOnStart;
	public bool RandomPitch;
	public float RandomPitchRange = 0.05f;
	public bool waitToFinish;
	
	
	void Start(){
		audioSrc = GetComponent<AudioSource>();
		audioSrc.clip = audioClp[0];
		if (playOnStart) {
			StartCoroutine(waiter());
		}
	}
	IEnumerator waiter(){
		yield return new WaitForSeconds(Random.Range(0,6));
		Play ();
	}
	public void Play(int clipPosition=0){
		if (audioSrc.isPlaying) {
			if (waitToFinish) {
				return;
			} else{
			}
		}
		//Clip Position: If Random Clip is disabled you can chose the clip you want to play with AudioController.Play(clipPosition);
		//If invalid clip position is selected, clip at position 0 will be used
		if(clipPosition<audioClp.Length && clipPosition>=0){
			audioSrc.clip = audioClp[clipPosition];
		}else{
			audioSrc.clip = audioClp[0];
			Debug.Log("Audio Clip not found/not existing. Used Default one instead!");
		}

		
		if (audioSrc.pitch != 1) {
			audioSrc.pitch = 1f;
		}
		if (RandomPitch) {
			pitchRandomizer (RandomPitchRange);
		}
		if (RandomClip && audioClp.Length > 1) {
			if (waitToFinish) {
				StartCoroutine (waitForSound ());
			} else {
				audioSrc.Stop ();
				clipRandomizer ();
			}
		}
		if(!audioSrc.isPlaying){
			audioSrc.Play();
		}

	}
	public void Stop(){
		audioSrc.Stop();
	}

	public void changeClip(int a, bool startPlaying=false){
		if(audioSrc.isPlaying){
			audioSrc.Stop();
		}
		if (a < audioClp.Length) {
			audioSrc.clip = audioClp [a];
		} else {
			Debug.Log ("Tried to load audioclip, that does not exist. Check your changeClip() calls.");
		}
		if(startPlaying){
			audioSrc.Play();
		}
	}

	void clipRandomizer(){
		audioSrc.clip = audioClp[Random.Range(0,audioClp.Length)];
	}

	void pitchRandomizer(float f){
		audioSrc.pitch = audioSrc.pitch+Random.Range (-f, f);
	}

	IEnumerator waitForSound(){
		while (audioSrc.isPlaying) {
			yield return null;
		}
		clipRandomizer ();
	}
}
