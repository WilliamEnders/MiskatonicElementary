using UnityEngine;
using System.Collections;

public class frogScript : MonoBehaviour {

	private Vector3 pos;
	private Vector3 randPlace;
	private float dist;
	private Vector3 goPlace;
	private Animator anim;

	void Start(){
		anim = GetComponentInChildren<Animator> ();
		pos = transform.position;
		dist = 5;
	}

	void Update(){
		if (transform.position != goPlace) {
			transform.position = Vector3.Lerp (transform.position, goPlace, 0.1f);
			anim.Play ("FrogJump");
		} else {
			//print ("same");
			anim.Play ("FrogStand");
		}
	}

	void OnTriggerEnter(Collider hitInfo){
		if(hitInfo.name == "player"){
			randPlace = new Vector3 (Random.Range(pos.x - dist, pos.x + dist), 0, Random.Range(pos.z - dist, pos.z + dist));
			Jump ();
		}
	}

	void Jump(){
		while (!canJump (randPlace)) {
			randPlace = new Vector3 (Random.Range(pos.x - dist, pos.x + dist), 0, Random.Range(pos.z - dist, pos.z + dist));
		}
		goPlace = randPlace;

	}

	static bool canJump(Vector3 pos){
		Collider[] hitColliders = Physics.OverlapSphere(pos, 2);
		if (hitColliders.Length >= 1) {
			return false;
		} else {
			return true;
		}

	}

}
