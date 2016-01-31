using UnityEngine;
using System.Collections;

public class SoccerGoal : MonoBehaviour {

	private GameObject rose;
	private bool roseTriggered = false;
	private bool roseGrowing = false;
	public float roseGrowSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		rose = GetComponentInChildren<PlayerInteractable> ().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (roseGrowing) {
			if (rose.transform.localScale.x < 1) {
				float scale = rose.transform.localScale.x + roseGrowSpeed * Time.fixedDeltaTime;
				rose.transform.localScale = new Vector3 (scale, scale, scale);
			} else {
				roseGrowing = false;
				rose.transform.localScale = new Vector3 (1, 1, 1);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ball" && !roseTriggered) {
			roseTriggered = true;
			roseGrowing = true;
		}
	}
}
