using UnityEngine;
using System.Collections;

public class frogScript : MonoBehaviour {

	private Vector3 pos;
	private Vector3 randPlace;
	private float dist;
	private Vector3 origPlace;
	private Vector3 goPlace;
	private Animator anim;
	private float speed;
	private SpriteRenderer sprite;

	private float height;
	private float startTime;
	private float journeyLength;

	void Start(){
		sprite = GetComponentInChildren<SpriteRenderer> ();
		anim = GetComponentInChildren<Animator> ();
		pos = transform.position;
		dist = 3;
		speed = 10f;
		height = 0f;
	}

	void Update(){


		if(transform.position != goPlace){
			if (transform.position.x > goPlace.x) {
				sprite.flipX = false;
			} else {
				sprite.flipX = true;
			}
			anim.Play ("FrogJump");
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
			height = Mathf.Clamp( (-Mathf.Pow(((fracJourney * 2) - 1) , 2) + 1) , 0, 1);
			transform.position = new Vector3 (Mathf.Lerp(origPlace.x, goPlace.x, fracJourney),height,Mathf.Lerp(origPlace.z, goPlace.z, fracJourney));

		} else {
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
		origPlace = transform.position;
		goPlace = randPlace;
		startTime = Time.time;
		journeyLength = Vector3.Distance(origPlace, goPlace);

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
