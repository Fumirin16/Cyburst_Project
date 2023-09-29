//作成者地引翼
//ステージを動かす（スクロール）
//goal地点にきたら止まる
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
        //ステージ移動
        if (key == true)
        {
            transform.position -= speed * Time.deltaTime * transform.forward;
        }

        //ゴール地点にいったら止まる
        if (U_TimeCounter.IsTimeOver())
        {
            key = false;
        }
    }
}
