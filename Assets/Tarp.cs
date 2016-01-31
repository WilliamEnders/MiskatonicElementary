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
			string query = "";
			int counter = 0;
			foreach (int element in circle.elements) {
				if (element == 0) {
					query += "earth";
				} else if (element == 1) {
					query += "fire";
				} else if (element == 2) {
					query += "organic";
				} else if (element == 3) {
					query += "water";
				} else if (element == 4) {
					query += "air";
				}
				counter++;
				if (counter <= 4) {
					query += ",";
				}
			}
			Application.OpenURL ("http://williamenders.github.io/MiskatonicElementary/index.html?elements=" + query);
		}
	}
}
