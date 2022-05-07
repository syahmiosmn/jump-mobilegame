using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player" && CoinScore.coinScore >=10)
        {
            Speed.speed -= 0.5f;
            CoinScore.coinScore -= 10;
            Debug.Log("slowed");

        }
    }
}
