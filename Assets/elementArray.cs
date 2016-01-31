using UnityEngine;
using System.Collections;

public class elementArray : MonoBehaviour {

	public int[] elements;
	public Sprite[] tokens;

	public int itemNum;

	private Animator tarpAnimator;

	void Start() {
		tarpAnimator = GameObject.FindGameObjectWithTag ("Tarp").GetComponent<Animator> ();
	}

	public void CheckForCompletion() {
		if (itemNum >= 4) {
			tarpAnimator.Play ("Flashing");
		}
	}

	public void AddElement(int element) {
		elements [itemNum] = element;
		itemNum++;
		CheckForCompletion ();
	}
}
