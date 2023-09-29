//FontでScore表示
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class U_Score : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        ScoreText.text = "<sprite=" + 0 + ">";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int amount)
    {
        score += amount;
        ScoreText.text = GetScoreText();
    }

    public static string GetScoreText()
    {
        string s = score.ToString();
        string rtnStr = "";

        // 文字列を一文字ずつ変換
        for (int i = 0; i < s.Length; i++)
        {
            string convStr = "";

            convStr += s[i].ToString();            // 「<sprite=【IndexのID】>」の形に変換
            rtnStr += "<sprite=" + convStr + ">";
        }
        return rtnStr;
    }
}