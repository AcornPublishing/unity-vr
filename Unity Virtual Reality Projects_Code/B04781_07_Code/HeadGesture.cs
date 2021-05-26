using UnityEngine;
using System.Collections;

public class HeadGesture : MonoBehaviour {
	public bool isFacingDown = false;
	public bool isMovingDown = false;
	public bool isJump = false;
	public float sweepRate = 100.0f;
	public float jumpRate = 1.0f;

	private Camera camera;
	private float previousCameraAngle;
	private float previousHeight;

	void Start () {
		camera = GameObject.FindWithTag ("MeCamera").GetComponent<Camera>();
		previousCameraAngle = CameraAngleFromGround ();
		previousHeight = camera.transform.localPosition.y;
	}

	void Update () {
		isFacingDown = DetectFacingDown ();
		isMovingDown = DetectNoddingDown (); // isNoddingDown
		isJump = DetectJump ();
	}

	private float CameraAngleFromGround () {
		return Vector3.Angle (Vector3.down, camera.transform.rotation * Vector3.forward);
	}

	private bool DetectFacingDown () {
		return (CameraAngleFromGround () < 60.0f);
	}

	private bool DetectNoddingDown () {
		float angle = CameraAngleFromGround ();
		float deltaAngle = previousCameraAngle - angle;
		float rate = deltaAngle / Time.deltaTime;
		previousCameraAngle = angle;
		return (rate >= sweepRate);
	}
	
	private bool DetectJump () {
		float height = camera.transform.localPosition.y;
		float deltaHeight = height - previousHeight;
		float rate = deltaHeight / Time.deltaTime;
		previousHeight = height;
		return (rate >= jumpRate);
	}
}
