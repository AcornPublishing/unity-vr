using UnityEngine;
using System.Collections;

public class BallGame : MonoBehaviour {
	public GameObject ball;
	public float startHeight = 10f;
	public float fireInterval = 5f;
	public AudioClip fireSound;

	private float nextBallTime = 0.0f;
	private GameObject activeBall;
	private GameObject head;
	private AudioSource audio;

	void Start () {
		head = GameObject.Find ("MeHead");
		audio = GetComponent<AudioSource> ();
	}
	
	void Update () {
		if (Time.time > nextBallTime) {
			nextBallTime = Time.time + fireInterval;
			audio.PlayOneShot (fireSound);
			Vector3 position = new Vector3( head.transform.position.x, startHeight, head.transform.position.z + 0.2f );
			activeBall = Instantiate( ball, position, Quaternion.identity ) as GameObject;
		} 
	}
}
