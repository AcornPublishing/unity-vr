using UnityEngine;
using System.Collections;

public class FlippinDashboard : MonoBehaviour {
	private Camera camera;
	private bool isOpen;
	private Vector3 startRotation;

	public float sweepRate = 180.0f;
	private float previousCameraAngle;
	private float timer = 0.0f;

	void Start() {
		camera = GameObject.FindWithTag ("MeCamera").GetComponent<Camera>();
		startRotation = transform.eulerAngles;
		CloseDashboard ();
		previousCameraAngle = CameraAngleFromGround ();
	}

	void Update() {
		if (GestureLookDown ()) {
			OpenDashboard ();
		} else if (!LookingDown()) {
			CloseDashboard ();
		}
	}

	private bool GestureLookDown() {
		float angle = CameraAngleFromGround ();
		float deltaAngle = previousCameraAngle - angle;
		previousCameraAngle = angle;
		float rate = deltaAngle / Time.deltaTime;
		return (rate >= sweepRate);
	}

	private float CameraAngleFromGround() {
		float cameraAngle = Mathf.Deg2Rad * camera.transform.rotation.eulerAngles.x;
		float ground = Mathf.Deg2Rad * 90.0f;
		float angle = Mathf.Rad2Deg * Mathf.Abs ( Mathf.DeltaAngle (cameraAngle, ground) );
		if (angle > 180.0f)
			angle = 360.0f - angle;
		//Debug.Log (angle);
		return angle;
	}

	private bool LookingDown() {
		timer -= Time.deltaTime;
		float xRot = camera.transform.rotation.eulerAngles.x;
		return (xRot >= 45.0f && xRot <= 90.0f);
	}

	private void CloseDashboard() {
		if (isOpen && timer <= 0.0f) {
			gameObject.transform.eulerAngles = new Vector3 (180f, startRotation.y, startRotation.z);
			isOpen = false;
		}
	}

	private void OpenDashboard() {
		if (!isOpen) {
			gameObject.transform.eulerAngles = startRotation;
			isOpen = true;
			timer = 3.0f;
		}
	}
}
