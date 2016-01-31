using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private SpriteRenderer ren;
	private Animator anim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		ren = GetComponentInChildren<SpriteRenderer> ();
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		if (rb.velocity != Vector3.zero) {
			if (GetComponent<AudioSource> ().isPlaying == false) {
				GetComponent<AudioSource> ().Play ();
			}
		} else if (rb.velocity == Vector3.zero) {
			GetComponent<AudioSource> ().Stop ();
		}
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("crouch")) {
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rb.velocity = movement * speed;
		}

		if(rb.velocity.x > 0){
			ren.flipX = true;
		}
		if(rb.velocity.x < 0){
			ren.flipX = false;
		}

		if (rb.velocity == Vector3.zero) {
			if (Input.GetKeyDown (KeyCode.E)) {
				anim.Play ("crouch");
			}
			if(!anim.GetCurrentAnimatorStateInfo(0).IsName("crouch")){
			anim.Play ("stand");
			}
		} else {
			anim.Play ("walk");
		}
			

	}
}
