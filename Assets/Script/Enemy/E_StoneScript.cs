//�쐬�Ғn����
//Stone�̃X�N���v�g
//Stone��Bat�ɓ���������Drone�ɓ���
//enemy�̃^�[�Q�b�g�I��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_StoneScript : MonoBehaviour
{
    static readonly int SCENE_MAX = 5;
    public GameObject[] myArray = new GameObject[SCENE_MAX];
    public GameObject[] targetArray = new GameObject[SCENE_MAX]; 
    public GameObject barriar;
    public AudioClip bounceSE;
    public AudioClip hitSE;

    private GameObject target;
    private Rigidbody rb;
    private int enemySelect;
    private bool stoneHit = false;
    private float power = 90f;
    private Renderer KonRenderer;
    private Renderer enemyRenderer1;
    private Renderer enemyRenderer2;
    private float bounce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        KonRenderer = GetComponent<Renderer>();
        enemyRenderer1 = GameObject.Find("B_ENEMY1").GetComponent<Renderer>();
        enemyRenderer2 = GameObject.Find("B_ENEMY2").GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        barriar.SetActive(false);

        //���L�[
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            enemySelect++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            enemySelect--;
        }

        enemySelect = (enemySelect + SCENE_MAX) % SCENE_MAX;
        target = myArray[enemySelect];

        //targetUI�̕\����\��
        for (int i = 0; i < SCENE_MAX; i++)
        {
            targetArray[i].SetActive(i == enemySelect);
        }

        //�o���A�G����������o���A�\��
        if(enemyRenderer1.isVisible || enemyRenderer2.isVisible)
        {
            barriar.SetActive(true);
        }

        if (KonRenderer.isVisible)
        {
            if (stoneHit == true && target.activeSelf == true)
            {
                transform.LookAt(target.transform);
                rb.velocity = transform.forward.normalized * power;
            }
        }
        else if(transform.position.z < -5)
        {
            //���������ɂ�������폜
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bat":
                Debug.Log("hit");
                stoneHit = true;
                AudioSource.PlayClipAtPoint(hitSE, transform.position);
                break;

            case "Enemy":
                stoneHit = false;
                if (enemyRenderer1.isVisible || enemyRenderer2.isVisible)
                {
                    AudioSource.PlayClipAtPoint(bounceSE, transform.position);
                    //�o���A���������璵�˕Ԃ�
                    rb.AddForce(-bounce, 0, 0, ForceMode.Impulse);
                }
                break;
        }
    }
}
