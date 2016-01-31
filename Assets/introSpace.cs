using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class introSpace : MonoBehaviour {

	public Sprite[] screens;
	private int num;
	private Image img;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image> ();
		num = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			num++;
		}
		if(num < 3){
		img.overrideSprite = screens[num];
		}
		if(num == 3){
			Application.LoadLevel ("Scene3");
		}
	}
}
