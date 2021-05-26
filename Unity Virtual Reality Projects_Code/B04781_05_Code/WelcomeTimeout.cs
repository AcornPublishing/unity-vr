using UnityEngine;
using System.Collections;

public class WelcomeTimeout : MonoBehaviour {
	private float timer = 15.0f;

	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0.0) {
			this.gameObject.SetActive(false);
		}
	}
}
