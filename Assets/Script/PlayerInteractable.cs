using UnityEngine;
using System.Collections;

public class PlayerInteractable : MonoBehaviour {

	private PlayerInteractBox interactBox;

	public GameObject frog;
	public GameObject salamander;
	private elementArray circle;
	private Rigidbody player;
	public bool active = true;

	// Use this for initialization
	void Start () {
		interactBox = GameObject.FindGameObjectWithTag ("PlayerInteractBox").GetComponent<PlayerInteractBox>();
		circle = GameObject.Find ("Main Circle").GetComponent<elementArray>();
		player = GameObject.Find ("player").GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && interactBox.interactObject != null && interactBox.interactObject.name == name && player.velocity == Vector3.zero) {
			print ("player interact with: " + interactBox.interactObject.name);
			if (interactBox.interactObject.name == "Pond") {
				Instantiate (frog, transform.position, Quaternion.identity);
				if (interactBox.interactObject.GetComponent<AudioSource> ().isPlaying == false) {
					interactBox.interactObject.GetComponent<AudioSource> ().Play ();
				}
			} else if (interactBox.interactObject.tag == "Rock") {
				Instantiate (salamander, transform.position, Quaternion.identity);
				DestroyInteraction ();
			} else if (interactBox.interactObject.tag == "Frog") {
				if (interactBox.interactObject.GetComponent<frogScript> ().jumpNum <= 0) {
					circle.AddElement (3);
					DestroyInteraction ();
				}
			} else if (interactBox.interactObject.tag == "Salamander") {
				if (interactBox.interactObject.GetComponent<salaScript> ().jumpNum <= 0) {
					circle.AddElement (1);
					DestroyInteraction ();
				}
			} else if (interactBox.interactObject.tag == "Feather") {
				circle.AddElement (4);
				DestroyInteraction ();
			} else if (interactBox.interactObject.name == "SeveredHand") {
				circle.AddElement (2);
				DestroyInteraction ();
			} else if (interactBox.interactObject.name.Contains("BirdTree")) {
				active = false;
				BirdAnimator birdAnim = interactBox.interactObject.GetComponentInChildren<BirdAnimator> ();
				birdAnim.Fly ();
				interactBox.StopInteraction ();
			} else if (interactBox.interactObject.name == "Rose") {
				circle.AddElement (0);
				DestroyInteraction ();
			}
		}
	}

	void DestroyInteraction() {
		Destroy (interactBox.interactObject);
		interactBox.StopInteraction ();
	}
}
