﻿using UnityEngine;
using System.Collections;

public class buttonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){
		Application.LoadLevel ("IntroScreen");
	}

	public void Credits(){
		Application.LoadLevel ("CreditsScreen");
	}
	public void Back(){
		Application.LoadLevel ("MainMenu");
	}
}
