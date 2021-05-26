using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonExecuteTest : MonoBehaviour {
	private GameObject startButton, stopButton;
	private bool on = false;
	private float timer = 5.0f;

	void Start () {
		startButton = GameObject.Find ("StartButton");
		stopButton = GameObject.Find ("StopButton");
	}
	
	void Update () {
//		if (Input.inputString != "") {
//			PointerEventData data = new PointerEventData (EventSystem.current);
//			if (on) {
//				ExecuteEvents.Execute<IPointerClickHandler> (stopButton, data, ExecuteEvents.pointerClickHandler);
//				on = false;
//			} else {
//				ExecuteEvents.Execute<IPointerClickHandler> (startButton, data, ExecuteEvents.pointerClickHandler);
//				on = true;
//			}
//		}
		timer -= Time.deltaTime;
		if (timer < 0.0f) {
			on = !on;
			timer = 5.0f;

			PointerEventData data = new PointerEventData (EventSystem.current);
			if (on) {
				ExecuteEvents.Execute<IPointerClickHandler> (startButton, data, ExecuteEvents.pointerClickHandler);
			} else {
				ExecuteEvents.Execute<IPointerClickHandler> (stopButton, data, ExecuteEvents.pointerClickHandler);
			}
		}

	}
}
