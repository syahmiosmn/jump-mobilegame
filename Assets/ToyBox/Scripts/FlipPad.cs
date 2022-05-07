using UnityEngine;
using System.Collections;

public class FlipPad : MonoBehaviour {

	private Animator ani;

	public bool state = false;

	public float flipTime = 4;

	private float timer;

	// Use this for initialization
	void Start () {
		ani = gameObject.GetComponent<Animator> ();
		state = false;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;
		if (timer >= flipTime) {
			if (state == false) {
				timer = 0;
				ani.SetBool ("flip1", true);
				state = true;
			}
			else if (state == true) {
				timer = 0;
				ani.SetBool ("flip1", false);
				state = false;
			}
		}

	}
}
