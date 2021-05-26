using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	void Update () {
		if (transform.position.y < -5f) {
			Destroy (gameObject);	
		}
	}
}
