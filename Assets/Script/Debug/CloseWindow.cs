//�쐬�Ғn����
//�v���C��ʁi�r���h������j��Esc�L�[��������I���
//�f�o�b�O�p
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�G�X�P�[�v�L�[
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
