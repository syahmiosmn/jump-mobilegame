using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject background;
    public GameObject movingBlock;
    public GameObject coinBlock;
    public GameObject powerBlock;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        SaveScore.score = 0;
        Speed.speed = 0;
        CoinScore.coinScore = PlayerPrefs.GetInt("coinScore", CoinScore.coinScore);
        BlockSpawn();
    }

    
    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("coinScore", CoinScore.coinScore);

    }

    public void BlockSpawn()
    {
        int rng = Random.Range(0, 2);
        int box = Random.Range(1,11);
        int spawnDirection = 1;

        if (rng <= 0)
        {
            spawnDirection = -1;
        }

        if (box <= 3)
        {
            Instantiate(coinBlock, new Vector3(10 * spawnDirection, 0 + (SaveScore.score * 2.54f), 0), Quaternion.Euler(0, 270 * spawnDirection, 0));
        }
        else if(box == 4)
            Instantiate(powerBlock, new Vector3(10 * spawnDirection, 0 + (SaveScore.score * 2.54f), 0), Quaternion.Euler(0, 270 * spawnDirection, 0));
        else
            Instantiate(movingBlock, new Vector3(10 * spawnDirection, 0 + (SaveScore.score * 2.54f), 0), Quaternion.Euler(0, 270 * spawnDirection, 0));


            Instantiate(background, new Vector3(0, 25 + (SaveScore.score * 4), 6), Quaternion.Euler(0, 0, 0));


    }
}

public static class SaveScore
{
    public static int score = 0;
}

public static class CoinScore
{
    public static int coinScore = 0;
}

public static class Speed
{
    public static float speed = 0f;
}
