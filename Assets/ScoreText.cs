using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        int i;
        string s;
        i = SaveScore.score;
        s = i.ToString();
        scoreText.text = "Score: " + s;
    }
}
