// Unity Virtual Reality Projects
// Chapter 5 version
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LookMoveTo : MonoBehaviour {
	public GameObject ground;

	private Camera camera;
	private Transform infoBubble;
	private Text messageText;

	void Start() {
		camera = GameObject.FindWithTag ("MeCamera").GetComponent<Camera>();
		infoBubble = transform.Find ("InfoBubble");
		if (infoBubble != null) {
			messageText = infoBubble.Find ("Text").GetComponent<Text> ();
		}
	}

	void Update () {
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
				//	Debug.Log ("Hit (x,y,z): " + hit.point.x + ", " + hit.point.y + ", " + hit.point.z);
				if (infoBubble != null) {
					messageText.text = "X:" + hit.point.x.ToString("F2") + ", Z:" + hit.point.z.ToString("F2");

					infoBubble.LookAt(camera.transform.position);
					infoBubble.Rotate ( 0.0f, 180.0f, 0.0f );
				}
				transform.position = hit.point;
			}
		}
	}

}
