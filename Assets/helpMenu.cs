using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class helpMenu : MonoBehaviour {

	private Image img;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image> ();	
		img.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			if (img.enabled == false) {
				img.enabled = true;
			} else {
				img.enabled = false;
			}
		}
	}
}
