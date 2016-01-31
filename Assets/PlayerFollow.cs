using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

	private Rigidbody rb;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		rb = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = rb.transform.position + offset;
	}
}
