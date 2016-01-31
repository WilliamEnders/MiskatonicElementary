using UnityEngine;
using System.Collections;

public class PlayerInteractable : MonoBehaviour {

	private PlayerInteractBox interactBox;

	public GameObject frog;
	public float clicks = 6;

	// Use this for initialization
	void Start () {
		interactBox = GameObject.FindGameObjectWithTag ("PlayerInteractBox").GetComponent<PlayerInteractBox>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && interactBox.interactObject.name == name) {
			print ("player interact with: " + interactBox.interactObject.name);
			if (interactBox.interactObject.name == "Bone") {
				// do something w/ bone
			} else if (interactBox.interactObject.name == "Tree") {
				// do something w/ tree
			}else if(interactBox.interactObject.name == "Pond"){
			Instantiate (frog, transform.position, Quaternion.identity);
			} else if (interactBox.interactObject.name == "SeveredHand") {
				print ("hand");
				clicks = clicks - 1;
				print (clicks);
				if (clicks <= 0) {
					print ("done");
				}
			}
		}
	}
}
