using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class E_Bomb_Count : MonoBehaviour
{
   // public TextMeshProUGUI TimeText; �f�o�b�N�p

    public float total_Time;
    int seconds;
    public bool bomb_judge = false;

    //�C���X�^���X���G���[�o�Ȃ��悤�ɂ����^��----
    public static E_Bomb_Count instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //----------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //�f�o�b�N�p
        //  TimeText = GameObject.Find("Timer_debug").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bomb_judge==false)
        {
            if (total_Time > 1.0f)//�J�E���g��1�ȏ�
            {
                total_Time -= Time.deltaTime;
                seconds = (int)total_Time;
               // TimeText.text = "Timer :" + seconds;
            }
            else//�J�E���g��0.9�ȉ��ɂȂ����Ƃ�
            {
                //bomb_judge = true;
                //Debug.Log("true");
            }
        }
    }
}
