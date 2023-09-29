//�쐬�Ғn����
//�G��Stone�����������������i�G�ƃ{�[�����j
//�G�����̋����ۂ�
//�|������P�O�O�_
//player�Ƀ^�[�Q�b�g����������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Maneger : MonoBehaviour
{
    [SerializeField] public Transform player_pos;//player�̈ʒu
    [SerializeField] public GameObject particleObject;//effect�̃I�u�W�F�N�g
    public float interval;//Enemy�\���̃C���^�[�o��
    public float floating = 0.1f; //���V����ϐ�0�`1�͈̔͂œG���Ƃɕς���
    public float x; //�G�̂����W�@-5,-3,0,3,5
    public float pos_y;
    public AudioClip explosionSE;

    private U_Score us;//UI�QScore
    private float pz;//player��Z�ʒu
    private float time;
    private int scoreValue = 100;//Score�̕ϐ�
    private float y;
    private Renderer enemyRenderer1;
    private Renderer enemyRenderer2;

    // Start is called before the first frame update
    void Start()
    {
        us = GameObject.Find("S_manage").GetComponent<U_Score>();
        enemyRenderer1 = GameObject.Find("B_ENEMY1").GetComponent<Renderer>();
        enemyRenderer2 = GameObject.Find("B_ENEMY2").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //enemy���c�ɕ��V������
        time += Time.deltaTime;
        y = 0.5f * Mathf.PerlinNoise(time, floating);

        //�v���C���[�̂��|�W���擾
        //pz = GameObject.Find("player").transform.position.z;

        //�G�̈ʒu
        Vector3 targetposition = new Vector3(x, pos_y + y, 10);

        //�G���ォ��o��
        transform.position = Vector3.MoveTowards(transform.position,targetposition, 0.1f);

        //player�Ƀ^�[�Q�b�g����������
        transform.LookAt(player_pos);

        //�S�[���ɂ�������h���[����\��
        if (U_TimeCounter.IsTimeOver())
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shot")
        {
            if (enemyRenderer1.isVisible || enemyRenderer2.isVisible)
            {
                return;
            }

            //�I�[�f�B�I���Đ�
            AudioSource.PlayClipAtPoint(explosionSE, transform.position);
            //Score�̒ǉ�
            us.AddScore(scoreValue);
            //�R�[���̏���
            Destroy(other.gameObject);
            //�G�t�F�N�g�̐���
            Instantiate(particleObject, this.transform.position, Quaternion.identity);
            //�h���[���̔�\��
            gameObject.SetActive(false);
            //���b��Ƀh���[����\������
            Invoke(nameof(SpawnInterval), interval);
        }
    }

    void SpawnInterval()
    {
        //�G�̕\��
        gameObject.SetActive(true);
        //�X�|�[���ʒu����ړ�
        this.transform.position = new Vector3(x, 7f + y, 10);
    }
}
