using UnityEngine;
using System.Collections;

public class BirdAnimator : MonoBehaviour {

	private Animator animator;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private bool flying = false;
	private float startTime;
	private float flightTime = 3;

	public GameObject feather;
	private bool featherSpawned = false;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (flying) {
			float distCovered = (Time.time - startTime) / flightTime;
			float newX = Mathf.Lerp (startPosition.x, endPosition.x, distCovered);
			float newY = Mathf.Lerp (startPosition.y, endPosition.y, distCovered);
			float newZ = Mathf.Lerp (startPosition.z, endPosition.z, distCovered);
			transform.position = new Vector3 (newX, newY, newZ);

			if (distCovered > 0.2 && !featherSpawned) {
				featherSpawned = true;
				Instantiate (feather, transform.position, Quaternion.identity);
			}
		}
	}

	public void Fly() {
		animator.Play ("Fly");
		flying = true;
		startPosition = transform.position;
		endPosition = new Vector3 (transform.position.x - 10, transform.position.y + 10, transform.position.z + 5);
		startTime = Time.time;
	}
}
