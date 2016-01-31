using UnityEngine;
using System.Collections;

public class Tarp : MonoBehaviour {

	private elementArray circle;

	// Use this for initialization
	void Start () {
		circle = GameObject.Find ("Main Circle").GetComponent<elementArray>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player" && circle.IsCompleted()) {
			Application.OpenURL ("http://williamenders.github.io/MiskatonicElementary/");
		}
	}
}
