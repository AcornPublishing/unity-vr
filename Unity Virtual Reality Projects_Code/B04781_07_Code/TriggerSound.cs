using UnityEngine;
using System.Collections;

public class TriggerSound : MonoBehaviour {
	public AudioClip hitSound;
	private AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other) {
		audio.PlayOneShot (hitSound);
	}

}
