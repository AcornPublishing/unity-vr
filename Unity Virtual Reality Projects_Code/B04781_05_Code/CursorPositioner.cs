using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CursorPositioner : MonoBehaviour {
	private Camera camera;
	private float defaultPosZ;

	void Start () {
		camera = GameObject.FindWithTag ("MeCamera").GetComponent<Camera>();
		defaultPosZ = transform.localPosition.z;
	}
	
	void Update () {
		Ray ray = new Ray (camera.transform.position, camera.transform.rotation * Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			//Debug.Log (transform.localPosition + "D: " + hit.distance );
			if (hit.distance <= 1.0f) {
				transform.localPosition = new Vector3( 0, 0, hit.distance );
			} else {
				transform.localPosition = new Vector3( 0, 0, defaultPosZ );
			}
		}
	}
}
