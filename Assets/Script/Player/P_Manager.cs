//�v���C���[�����E�ړ�
//�v���C���[������łA�j���[�V����
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
    public float H_speed = 7.0f; //���̃X�s�[�h
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
        //�X�e�B�b�N�A(A,D)�L�[�ō��E�ړ�����
        moveX = Input.GetAxis("Horizontal") * H_speed;

        //�o�C�N�̃A�j���[�V����
        animator.SetFloat("turn_Left", (moveX < 0f) ? moveX : 0f);
        animator.SetFloat("turn_Right", (0f < moveX) ? moveX : 0f);

        //�v���C���[���E�ړ�
        direction = new Vector3(moveX, 0, 0);
        controller.SimpleMove(direction);

        //�v���C���[�̍s���͈�
        player_pos = transform.position;
        player_pos.x = Mathf.Clamp(player_pos.x, -5.0f, 5.0f);
        transform.position = player_pos;

        //Space�ŉE�ł�
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
        //Hit���Ă����珈�����s��Ȃ�
        if (isHit)
        {
            return;
        }
        //�t�F���X�ɂ��������烉�C�t������
        if (other.gameObject.tag == "wall")
        {
            //�I�[�f�B�I���Đ�
            AudioSource.PlayClipAtPoint(biribiriSE, transform.position);
            DontDestroyOnLoad(this);

            U_Life.instance.life_count--;
        }
    }

    //���[�V�������͂ق��̃��[�V�������͂����Ȃ�
    private void OnAnimatorMove()
    {
        animator.ResetTrigger("toR_Hit");
        animator.ResetTrigger("toL_Hit");
    }
}
