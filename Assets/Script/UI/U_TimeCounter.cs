using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class U_TimeCounter : MonoBehaviour
{
    [SerializeField] int minute; //��
    [SerializeField] float seconds; //�b
    static float leftTime;
    [SerializeField] TextMeshProUGUI timeText; //���Ԃ�\������Text�^�̕ϐ�
    [SerializeField] GameObject clear;

    void Start()
    {
        leftTime = minute * 60 + seconds;
        clear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        leftTime -= Time.deltaTime;

        minute = (int)leftTime / 60;
        seconds = leftTime - minute * 60;

        //���Ԃ�\������
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