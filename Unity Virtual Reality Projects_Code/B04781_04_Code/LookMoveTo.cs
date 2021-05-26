using UnityEngine;
using System.Collections;

public class LookMoveTo : MonoBehaviour {
	public Camera camera;
	public GameObject ground;

	void Update () {
//		Ray ray;
//		RaycastHit hit;
//		GameObject hitObject;
//
//		Debug.DrawRay (camera.transform.position, camera.transform.rotation * Vector3.forward * 100.0f);
//
//		ray = new Ray (camera.transform.position, camera.transform.rotation * Vector3.forward);
//		if (Physics.Raycast (ray, out hit)) {
//			hitObject = hit.collider.gameObject;
//			if (hitObject == ground) {
//				Debug.Log ("Hit (x,y,z): " + hit.point.ToString("F2"));
//				transform.position = hit.point;
//			}
//		}
		Ray ray;
		RaycastHit[] hits;
		GameObject hitObject;
		
		Debug.DrawRay (camera.transform.position, camera.transform.rotation * Vector3.forward * 100.0f);
		
		ray = new Ray (camera.transform.position, camera.transform.rotation * Vector3.forward);
		hits = Physics.RaycastAll (ray);
		for (int i=0; i < hits.Length; i++) {
			RaycastHit hit = hits [i];
			hitObject = hit.collider.gameObject;
			if (hitObject == ground) {
				Debug.Log ("Hit (x,y,z): " + hit.point.ToString("F2"));
				transform.position = hit.point;
			}
		}
	}

}
