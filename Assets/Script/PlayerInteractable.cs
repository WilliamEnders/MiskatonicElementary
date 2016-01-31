using UnityEngine;
using System.Collections;

public class PlayerInteractable : MonoBehaviour {

	private PlayerInteractBox interactBox;

	public GameObject frog;
	public float clicks = 6;
	private elementArray circle;

	// Use this for initialization
	void Start () {
		interactBox = GameObject.FindGameObjectWithTag ("PlayerInteractBox").GetComponent<PlayerInteractBox>();
		circle = GameObject.Find ("Main Circle").GetComponent<elementArray>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && interactBox.interactObject != null && interactBox.interactObject.name == name) {
			print ("player interact with: " + interactBox.interactObject.name);
			if (interactBox.interactObject.name == "Bone") {
				// do something w/ bone
			} else if (interactBox.interactObject.name == "Tree") {
				// do something w/ tree
			} else if (interactBox.interactObject.name == "Pond") {
				Instantiate (frog, transform.position, Quaternion.identity);
			} else if (interactBox.interactObject.tag == "Frog"){
				if(interactBox.interactObject.GetComponent<frogScript>().jumpNum == 0){
				circle.elements [circle.itemNum] = 3;
				circle.itemNum++;
				Destroy (interactBox.interactObject);
				}
			} else if (interactBox.interactObject.tag == "Salamander"){
				if (interactBox.interactObject.GetComponent<salaScript> ().jumpNum == 0) {
					circle.elements [circle.itemNum] = 1;
					circle.itemNum++;
					Destroy (interactBox.interactObject);
				}
			} else if (interactBox.interactObject.tag == "Feather"){
				circle.elements [circle.itemNum] = 4;
				circle.itemNum++;
				Destroy (interactBox.interactObject);
			}  else if (interactBox.interactObject.name == "SeveredHand") {
				if (clicks > 0) {
					clicks = clicks - 1;
				} else {
					circle.elements [circle.itemNum] = 2;
					circle.itemNum++;
					Destroy (interactBox.interactObject);
				}
			} else if (interactBox.interactObject.name == "BirdTree") {
				BirdAnimator birdAnim = interactBox.interactObject.GetComponentInChildren<BirdAnimator> ();
				birdAnim.Fly ();
			}
		}
	}
}
