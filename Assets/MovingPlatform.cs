using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MovingPlatform : MonoBehaviour {

	public bool upDown;

	public bool sideSide;

	private float timer;
	private int state = 0; //0 - move1, 1 - pause, 2- move2, 3 - pause2

	public float waitTime = 0;

	public float time = 3;

	public float speed;

    GameObject player;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
		state = 0;
		timer = 0;
        rb.useGravity = false;
        speed = Speed.speed + 5.0f + (SaveScore.score * 0.1f);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player" ) {
            speed = 0;
            GetComponent<BoxCollider>().enabled = false;
            GameObject gm;
            gm = GameObject.Find("GameManager");
            SaveScore.score++;
            gm.GetComponent<GameManager>().BlockSpawn();
            Debug.Log(SaveScore.score);
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            FindObjectOfType<AudioManager>().Play("landbox");
        }
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            player = GameObject.Find("Player");
            Destroy(player);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }*/

    // Update is called once per frame
    void Update () {

		if (sideSide == true) {
			if (state == 0) {
				timer += Time.deltaTime;
				transform.Translate (Vector3.forward * Time.deltaTime * speed);
				if (timer >= time) {
					timer = 0;
					state = 1;
				}
			}
			if (state == 1) {
				timer += Time.deltaTime;
				if (timer >= waitTime) {
					timer = 0;
					state = 2;
				}
			}
			if (state == 2) {
				timer += Time.deltaTime;
				transform.Translate (Vector3.forward * Time.deltaTime * -speed);
                if (timer >= time) {
					timer = 0;
					state = 3;
				}
			}
			if (state == 3) {
				timer += Time.deltaTime;
				if (timer >= waitTime) {
					timer = 0;
					state = 0;
				}
			}
		} 

		if (upDown == true) {
				if (state == 0) {
					timer += Time.deltaTime;
					transform.Translate (Vector3.up * Time.deltaTime * speed);
					if (timer >= time) {
						timer = 0;
						state = 1;
					}
				}
				if (state == 1) {
					timer += Time.deltaTime;
					if (timer >= waitTime) {
						timer = 0;
						state = 2;
					}
				}
				if (state == 2) {
					timer += Time.deltaTime;
					transform.Translate (Vector3.up * Time.deltaTime * -speed);
					if (timer >= time) {
						timer = 0;
						state = 3;
					}
				}
				if (state == 3) {
					timer += Time.deltaTime;
					if (timer >= waitTime) {
						timer = 0;
						state = 0;
					}
				}
			}

	}
}
