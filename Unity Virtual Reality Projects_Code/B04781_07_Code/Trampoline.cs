using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {
	public float bounceForce = 500f;

	void OnTriggerEnter( Collider other ) {
		//Debug.Log ("ENTER" + other);
		Rigidbody rb = other.GetComponent<Rigidbody> ();
		if (rb != null) {
			//Debug.Log(" Rigidbody");
			rb.AddForce (Vector3.up * bounceForce);
		} else {
			HeadLookWalk locomotor = other.GetComponent<HeadLookWalk> ();
			if (locomotor != null) {
				//Debug.Log (" HeadLookWalk");
				locomotor.bounceForce = bounceForce;
			}
		}
	}
}
