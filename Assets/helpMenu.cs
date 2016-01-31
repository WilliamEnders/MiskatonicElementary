using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class helpMenu : MonoBehaviour {

	private GameObject img;

	// Use this for initialization
	void Start () {
		img = GameObject.Find ("Help");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			if (!img.activeSelf) {
				img.SetActive (true);
				Time.timeScale = 0;
			} else {
				img.SetActive (false);
				Time.timeScale = 1;
			}
		}
	}
}
