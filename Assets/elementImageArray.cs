﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class elementImageArray : MonoBehaviour {

	private Image img;
	public int num;
	private GameObject circle;
	private elementArray script;

	// Use this for initialization
	void Start () {
		circle = GameObject.Find ("Main Circle");
		script = circle.GetComponent<elementArray> ();
		img = GetComponent<Image> ();
		//img.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		img.overrideSprite = script.tokens [script.elements[num]];
	}
}
