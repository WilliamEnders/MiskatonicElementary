using UnityEngine;
using System.Collections;

public class FeatherFall : MonoBehaviour {

	private bool falling = true;
	private Animator animator;
	public float fallSpeed;

	// Use this for initialization
	void Start () {
		Debug.Log ("feather start");
		animator = GetComponentInChildren<Animator> ();
		animator.Play ("Fall");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (falling) {
			Debug.Log ("feather falling: " + transform.position.y);
			if (transform.position.y > 0) {
				transform.position = new Vector3 (transform.position.x, transform.position.y - fallSpeed * Time.fixedDeltaTime, transform.position.z);
			} else {
				falling = false;
				transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
				animator.Play ("Idle");
			}
		}
	}
}
