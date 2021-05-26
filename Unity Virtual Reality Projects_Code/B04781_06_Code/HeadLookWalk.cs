using UnityEngine;
using System.Collections;

public class HeadLookWalk : MonoBehaviour {
  public float velocity = 0.7f;
  
  private Camera camera;
  private CharacterController controller;
  private AudioSource footsteps;
  private GameObject head;
  private GameObject body;
  private HeadGesture gesture;
  private bool walking;
  
  void Start () {
    camera     = GameObject.FindWithTag ("MeCamera").GetComponent<Camera>();
    controller = GetComponent<CharacterController> ();
    footsteps  = GetComponent<AudioSource> ();
    head       = GameObject.FindWithTag ("MeHead");
    body       = GameObject.FindWithTag ("MeBody");
    gesture    = GameObject.Find ("GameController").GetComponent<HeadGesture> ();
    walking    = false;
  }
  
  void Update () {
    if (gesture.isMovingDown || Input.anyKey) {
      walking = !walking;
    }
    if (walking) {
      controller.SimpleMove (camera.transform.forward * velocity);
      body.transform.rotation = Quaternion.Euler (new Vector3 (0f, head.transform.eulerAngles.y, 0f));
      if (!footsteps.isPlaying) {
        footsteps.Play ();
      }
    } else {
      footsteps.Stop ();
    }
  }
}
