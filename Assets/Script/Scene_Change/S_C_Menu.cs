//Menuに移動。スペースキー押したら音が流れて次のシーンに行く
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_C_Menu : MonoBehaviour
{
    [Tooltip("スタート時のSE")]
    public AudioClip StartSE;

    private AudioSource audioSource;
    //入力は一度だけさせるbool値
    private bool audioMode = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーを押したかつaudioModeがtrueだったら
        if(Input.GetKey(KeyCode.Space) && audioMode)
        {
            //SE流す
            audioSource.PlayOneShot(StartSE);
            //GoMenuにいくまで2秒待つ
            Invoke("GoMenu", 2.0f);
            //audioModeをfalseにして2回目の処理をさせない
            audioMode = false;
        }
    }

    private void GoMenu()
    {
        //Menuシーンに移行
        SceneManager.LoadScene("Menu");
    }
}
