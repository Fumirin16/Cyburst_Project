//作成者地引翼
//最終スコア表示
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class U_GetScore : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = U_Score.GetScoreText();
    }
}
