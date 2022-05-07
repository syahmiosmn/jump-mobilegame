using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    public TMP_Text coinText;
    // Update is called once per frame
    void Update()
    {
        int i;
        string s;
        i = CoinScore.coinScore;
        s = i.ToString();
        coinText.text = "Coin: " + s;
    }
}
