//Menu����Main�ARule�V�[���Ɉړ�
//button�I��
//�쐬�Ғn����
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

    [Tooltip("���艹")]
    public AudioClip ClickSE;
    [Tooltip("���̃V�[���ɂ����܂ł̊Ԋu����")]
    public float InvokeTime = 0.2f;
    [Tooltip("�����̃{�^��")]
    public Button LeftButton;
    [Tooltip("�E���̃{�^��")]
    public Button RightButton;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //���L�[����
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            select++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            select--;
        }

        //0��1�ɒl�𐧌�����
        select = Math.Clamp(select, 0, 1);

        //�X�y�[�X�L�[����
        bool is_press = (Input.GetKeyDown(KeyCode.Space));

        switch (select)
        {
            case 0:
                LeftButton.Select();
                if (is_press�@&& SceneManager.GetActiveScene().name == "Menu")
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
        //���[����ʂɍs��
        SceneManager.LoadScene("Rule");
    }
    private void onClickMainBotton()
    {
        //���C����ʂɍs��
        SceneManager.LoadScene("Main");
    }
    private void onClickTitleBotton()
    {
        //�^�C�g����ʂɍs��
        SceneManager.LoadScene("Title");
    }
    private void onClickExitBotton()
    {
        //�Q�[���I��
        Application.Quit();
    }
}
