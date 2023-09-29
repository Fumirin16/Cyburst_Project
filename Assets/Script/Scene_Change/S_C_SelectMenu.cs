//MenuからMain、Ruleシーンに移動
//button選択
//作成者地引翼
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class S_C_SelectMenu : MonoBehaviour
{
    private AudioSource audioSource;
    private float select = 0.0f;

    [Tooltip("決定音")]
    public AudioClip ClickSE;
    [Tooltip("次のシーンにいくまでの間隔時間")]
    public float InvokeTime = 0.2f;
    [Tooltip("左側のボタン")]
    public Button LeftButton;
    [Tooltip("右側のボタン")]
    public Button RightButton;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //矢印キー入力
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            select++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            select--;
        }

        //0か1に値を制限する
        select = Math.Clamp(select, 0, 1);

        //スペースキー入力
        bool is_press = (Input.GetKeyDown(KeyCode.Space));

        switch (select)
        {
            case 0:
                LeftButton.Select();
                if (is_press　&& SceneManager.GetActiveScene().name == "Menu")
                {
                    audioSource.PlayOneShot(ClickSE);
                    Invoke("onClickMainBotton", InvokeTime);
                }
                else if(is_press && SceneManager.GetActiveScene().name != "Menu")
                {
                    audioSource.PlayOneShot(ClickSE);
                    Invoke("onClickTitleBotton", InvokeTime);
                }
                break;
            case 1:
                RightButton.Select();
                if (is_press && SceneManager.GetActiveScene().name == "Menu")
                {
                    audioSource.PlayOneShot(ClickSE);
                    Invoke("onClickRuleBotton", InvokeTime);
                }
                else if(is_press && SceneManager.GetActiveScene().name != "Menu")
                {
                    audioSource.PlayOneShot(ClickSE);
                    Invoke("onClickExitBotton", InvokeTime);
                }
                break;
        }
    }
    private void onClickRuleBotton()
    {
        //ルール画面に行く
        SceneManager.LoadScene("Rule");
    }
    private void onClickMainBotton()
    {
        //メイン画面に行く
        SceneManager.LoadScene("Main");
    }
    private void onClickTitleBotton()
    {
        //タイトル画面に行く
        SceneManager.LoadScene("Title");
    }
    private void onClickExitBotton()
    {
        //ゲーム終了
        Application.Quit();
    }
}
