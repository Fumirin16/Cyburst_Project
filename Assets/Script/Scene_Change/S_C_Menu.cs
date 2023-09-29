//Menu�Ɉړ��B�X�y�[�X�L�[�������特������Ď��̃V�[���ɍs��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_C_Menu : MonoBehaviour
{
    [Tooltip("�X�^�[�g����SE")]
    public AudioClip StartSE;

    private AudioSource audioSource;
    //���͈͂�x����������bool�l
    private bool audioMode = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�X�y�[�X�L�[������������audioMode��true��������
        if(Input.GetKey(KeyCode.Space) && audioMode)
        {
            //SE����
            audioSource.PlayOneShot(StartSE);
            //GoMenu�ɂ����܂�2�b�҂�
            Invoke("GoMenu", 2.0f);
            //audioMode��false�ɂ���2��ڂ̏����������Ȃ�
            audioMode = false;
        }
    }

    private void GoMenu()
    {
        //Menu�V�[���Ɉڍs
        SceneManager.LoadScene("Menu");
    }
}
