using UnityEngine;
using System.Collections;

public class PlayerInteractBox : MonoBehaviour {

	private Rigidbody rb;
	public GameObject interactObject = null;

	// Use this for initialization
	void Start () {
		print ("new player interact box");
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		rb = player.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float input = Input.GetAxisRaw ("Horizontal");
		if (input != 0) {
			float xPos = (float)(input > 0 ? 0.8 : -0.8);
			Vector3 position = rb.transform.position;
			position.x += xPos;
			transform.position = position;
		}
	}

	void OnTriggerEnter(Collider other) {
		PlayerInteractable pi = other.gameObject.GetComponent<PlayerInteractable> ();
		if (pi != null && pi.active) {
			print ("Can interact with object: " + other.gameObject.name);
			GameObject.Find("Press E").GetComponent<SpriteRenderer> ().enabled = true;
			interactObject = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.GetComponent<PlayerInteractable> () != null) {
			print ("Can no longer interact with object: " + other.gameObject.name);
			StopInteraction ();
		}
	}

	public void StopInteraction () {
		GameObject.Find ("Press E").GetComponent<SpriteRenderer> ().enabled = false;
		interactObject = null;
	}
		
}
