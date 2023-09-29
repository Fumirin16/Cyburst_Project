//作成者地引翼
//敵とStoneが当たったら消える（敵とボールが）
//敵が一定の距離保つ
//倒したら１００点
//playerにターゲットを向かせる
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Maneger : MonoBehaviour
{
    [SerializeField] public Transform player_pos;//playerの位置
    [SerializeField] public GameObject particleObject;//effectのオブジェクト
    public float interval;//Enemy表示のインターバル
    public float floating = 0.1f; //浮遊する変数0～1の範囲で敵ごとに変える
    public float x; //敵のｘ座標　-5,-3,0,3,5
    public float pos_y;
    public AudioClip explosionSE;

    private U_Score us;//UI＿Score
    private float pz;//playerのZ位置
    private float time;
    private int scoreValue = 100;//Scoreの変数
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
        //enemyを縦に浮遊させる
        time += Time.deltaTime;
        y = 0.5f * Mathf.PerlinNoise(time, floating);

        //プレイヤーのｚポジを取得
        //pz = GameObject.Find("player").transform.position.z;

        //敵の位置
        Vector3 targetposition = new Vector3(x, pos_y + y, 10);

        //敵が上から出現
        transform.position = Vector3.MoveTowards(transform.position,targetposition, 0.1f);

        //playerにターゲットを向かせる
        transform.LookAt(player_pos);

        //ゴールにいったらドローン非表示
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

            //オーディオを再生
            AudioSource.PlayClipAtPoint(explosionSE, transform.position);
            //Scoreの追加
            us.AddScore(scoreValue);
            //コーンの消去
            Destroy(other.gameObject);
            //エフェクトの生成
            Instantiate(particleObject, this.transform.position, Quaternion.identity);
            //ドローンの非表示
            gameObject.SetActive(false);
            //○秒後にドローンを表示する
            Invoke(nameof(SpawnInterval), interval);
        }
    }

    void SpawnInterval()
    {
        //敵の表示
        gameObject.SetActive(true);
        //スポーン位置から移動
        this.transform.position = new Vector3(x, 7f + y, 10);
    }
}
