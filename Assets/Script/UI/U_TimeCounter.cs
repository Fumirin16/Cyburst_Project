using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class U_TimeCounter : MonoBehaviour
{
    [SerializeField] int minute; //分
    [SerializeField] float seconds; //秒
    static float leftTime;
    [SerializeField] TextMeshProUGUI timeText; //時間を表示するText型の変数
    [SerializeField] GameObject clear;

    void Start()
    {
        leftTime = minute * 60 + seconds;
        clear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        leftTime -= Time.deltaTime;

        minute = (int)leftTime / 60;
        seconds = leftTime - minute * 60;

        //時間を表示する
        timeText.text = minute.ToString("00") + "." + seconds.ToString("f2");

        if(IsTimeOver())
        {
            timeText.text = "";
            clear.SetActive(true);
            Invoke("GoClear", 5);
        }
    }
    public static bool IsTimeOver()
    {
        return leftTime <= 0f;
    }

    private void GoClear()
    {
        SceneManager.LoadScene("Clear");
    }
}