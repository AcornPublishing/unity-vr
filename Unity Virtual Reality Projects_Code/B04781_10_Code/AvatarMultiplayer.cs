using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.VR;

public class AvatarMultiplayer : NetworkBehaviour {

	public override void OnStartLocalPlayer () {

		if (isServer) {
			VRSettings.enabled = true;
		}

		GameObject camera = GameObject.FindWithTag ("MainCamera");
		transform.parent = camera.transform;
		transform.localPosition = Vector3.zero;
	}
}
