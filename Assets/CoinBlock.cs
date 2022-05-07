using UnityEngine;
using System.Collections;

public class CoinBlock : MonoBehaviour {

	public float speed;

    GameObject coin;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            coin = GameObject.Find("Coin");
            Destroy(coin);
            CoinScore.coinScore++;
            Debug.Log("Coins: "+ (CoinScore.coinScore));
        }
    }
}
