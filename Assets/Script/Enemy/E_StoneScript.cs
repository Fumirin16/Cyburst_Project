//作成者地引翼
//Stoneのスクリプト
//StoneがBatに当たったらDroneに動く
//enemyのターゲット選択
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

        //矢印キー
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

        //targetUIの表示非表示
        for (int i = 0; i < SCENE_MAX; i++)
        {
            targetArray[i].SetActive(i == enemySelect);
        }

        //バリア敵が見えたらバリア表示
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
            //自分より後ろにいったら削除
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
                    //バリアがあったら跳ね返る
                    rb.AddForce(-bounce, 0, 0, ForceMode.Impulse);
                }
                break;
        }
    }
}
