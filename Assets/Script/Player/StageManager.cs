//�쐬�Ғn����
//�X�e�[�W�𓮂����i�X�N���[���j
//goal�n�_�ɂ�����~�܂�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public float speed; //speed m/s
    private bool key = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�[�W�ړ�
        if (key == true)
        {
            transform.position -= speed * Time.deltaTime * transform.forward;
        }

        //�S�[���n�_�ɂ�������~�܂�
        if (U_TimeCounter.IsTimeOver())
        {
            key = false;
        }
    }
}
