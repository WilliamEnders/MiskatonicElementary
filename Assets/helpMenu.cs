﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class helpMenu : MonoBehaviour {

	private GameObject img;

	// Use this for initialization
	void Start () {
		img = GameObject.Find ("HelpSign");
		img.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q) && !img.activeSelf) {
			img.SetActive (true);
		} else if (Input.anyKeyDown && img.activeSelf) {
			img.SetActive (false);
		}
//		if(img.activeSelf){
//			Time.timeScale = 0;
//		}
//		if(!img.activeSelf){
//			Time.timeScale = 1;
//		}
	}
}
