using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

	void Start () {
		StartCoroutine (RePositionWithDelay()); 
	}

	IEnumerator RePositionWithDelay() {
		while (true) {
			SetRandomPosition();
			yield return new WaitForSeconds (5);
		}
	}

	void SetRandomPosition() {
		float x = Random.Range (-5.0f, 5.0f);
		float z = Random.Range (-5.0f, 5.0f);
		Debug.Log ("X,Z: " + x + ", " + z);
		transform.position = new Vector3 (x, 0.0f, z);
	}
}
