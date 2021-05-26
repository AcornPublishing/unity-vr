using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class ButtonExecute : MonoBehaviour {
	private Camera camera;
	private GameObject currentButton;
	private float timeToSelect = 3.0f;
	private float countDown = 3.0f;

	void Start () {
		camera = GameObject.FindWithTag ("MeCamera").GetComponent<Camera>();
	}
	
	void Update () {
		Ray ray = new Ray (camera.transform.position, camera.transform.rotation * Vector3.forward);
		RaycastHit hit;
		GameObject hitButton = null;
		PointerEventData data = new PointerEventData (EventSystem.current);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject.tag == "Button") {
				hitButton = hit.transform.parent.gameObject;
			}
		}
		if (currentButton != hitButton) {
			if (currentButton != null) { // unhighlight
				ExecuteEvents.Execute<IPointerExitHandler> (currentButton, data, ExecuteEvents.pointerExitHandler);
			}
			currentButton = hitButton;
			if (currentButton != null) { // highlight
				ExecuteEvents.Execute<IPointerEnterHandler> (currentButton, data, ExecuteEvents.pointerEnterHandler);
				countDown = timeToSelect;
			}
		}
		if (currentButton != null) {
			countDown -= Time.deltaTime;
			if (Input.anyKey || countDown < 0.0f) { // click
				ExecuteEvents.Execute<IPointerClickHandler> (currentButton, data, ExecuteEvents.pointerClickHandler);
				countDown = timeToSelect;
			}
		}
	}
}
