//プレイヤーが左右移動
//プレイヤーが走る打つアニメーション
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_Manager : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    private Vector3 player_pos;
    private Vector3 direction;
    private float moveX = 0;
    private GameObject stage;
    private StageManager stageManager;
    private U_TimeCounter timeCounter;
    public float H_speed = 7.0f; //横のスピード
    [SerializeField]public GameObject clear;
    public AudioClip biribiriSE;

    bool isHit;

    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        stage = GameObject.Find("Stages");
        stageManager = stage.GetComponent<StageManager>();
        clear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //スティック、(A,D)キーで左右移動する
        moveX = Input.GetAxis("Horizontal") * H_speed;

        //バイクのアニメーション
        animator.SetFloat("turn_Left", (moveX < 0f) ? moveX : 0f);
        animator.SetFloat("turn_Right", (0f < moveX) ? moveX : 0f);

        //プレイヤー左右移動
        direction = new Vector3(moveX, 0, 0);
        controller.SimpleMove(direction);

        //プレイヤーの行動範囲
        player_pos = transform.position;
        player_pos.x = Mathf.Clamp(player_pos.x, -5.0f, 5.0f);
        transform.position = player_pos;

        //Spaceで右打ち
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("toR_Hit");
        }

        if (U_TimeCounter.IsTimeOver())
        {
            transform.position += transform.forward * 0.8f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Hitしていたら処理を行わない
        if (isHit)
        {
            return;
        }
        //フェンスにあたったらライフが減る
        if (other.gameObject.tag == "wall")
        {
            //オーディオを再生
            AudioSource.PlayClipAtPoint(biribiriSE, transform.position);
            DontDestroyOnLoad(this);

            U_Life.instance.life_count--;
        }
    }

    //モーション中はほかのモーション入力させない
    private void OnAnimatorMove()
    {
        animator.ResetTrigger("toR_Hit");
        animator.ResetTrigger("toL_Hit");
    }
}
