using UnityEngine;
using System.Collections;

public class PlayerInteractable : MonoBehaviour {

	private PlayerInteractBox interactBox;

	// Use this for initialization
	void Start () {
		interactBox = GameObject.FindGameObjectWithTag ("PlayerInteractBox").GetComponent<PlayerInteractBox>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && interactBox.interactObject != null) {
			print ("player interact with: " + interactBox.interactObject.tag);
			if (interactBox.interactObject.tag == "Bone") {
				// do something w/ bone
			} else if (interactBox.interactObject.tag == "Tree") {
				// do something w/ tree
			}
		}
	}
}
