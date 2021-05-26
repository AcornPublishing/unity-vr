using UnityEngine;
using System.Collections;

public class HeadLookWalk : MonoBehaviour {
	public float velocity = 0.7f;
	public float gravity = 9.8f;
	public float bounceForce = 0.0f;
	public float jumpForce = 20.0f;

	private Camera camera;
	private CharacterController controller;
	private AudioSource footsteps;
	private GameObject head;
	private GameObject body;
	private HeadGesture gesture;
	private bool walking;
	private float verticalVelocity;
	private Vector3 moveDirection;

	void Start () {
		camera     = GameObject.FindWithTag ("MeCamera").GetComponent<Camera>();
		controller = GetComponent<CharacterController> ();
		footsteps  = GetComponent<AudioSource> ();
		head       = GameObject.FindWithTag ("MeHead");
		body       = GameObject.FindWithTag ("MeBody");
		gesture    = GetComponent<HeadGesture> ();
		walking    = false;
		verticalVelocity = 0.0f;
	}
	
	void Update () {
		if ((gesture != null && gesture.isMovingDown) || Input.anyKeyDown) {
			walking = !walking;
		}

		if (walking) {
//			controller.SimpleMove (camera.transform.forward * velocity);
			moveDirection = camera.transform.forward * velocity;
			body.transform.rotation = Quaternion.Euler (new Vector3 (0f, head.transform.eulerAngles.y, 0f));
			if (!footsteps.isPlaying) {
				footsteps.Play ();
			}
		} else {
			moveDirection = Vector3.zero;
			footsteps.Stop ();
		}

		if (controller.isGrounded) {	
			if (gesture.isJump) {
				Debug.Log ("JUMP!");
				verticalVelocity = jumpForce;
			} else {
				verticalVelocity = 0f;
			}
		}

		if (bounceForce != 0f) {
			verticalVelocity = bounceForce * 0.03f; 
			bounceForce = 0f;
		}
		moveDirection.y = verticalVelocity;
		verticalVelocity -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime );
	}
}
