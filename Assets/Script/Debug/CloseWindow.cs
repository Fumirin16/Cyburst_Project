//作成者地引翼
//プレイ画面（ビルドしたやつ）でEscキー押したら終わる
//デバッグ用
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
        //エスケープキー
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
