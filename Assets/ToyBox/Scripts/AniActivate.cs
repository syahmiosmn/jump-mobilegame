using UnityEngine;
using System.Collections;

public class AniActivate : MonoBehaviour {

	[Tooltip("Press E within range to activate Animation")]
	public bool hasBeenHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (hasBeenHit == false) {
			if (other.tag == "Player") {
				GetComponent<Animator> ().enabled = true;
				hasBeenHit = true;
			}
		}
	}
}
