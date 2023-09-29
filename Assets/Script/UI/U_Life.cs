//LifeのUI表示
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class U_Life : MonoBehaviour
{
    public GameObject[] LifeArray = new GameObject[3];
    public int life_count = 3;

    //インスタンスがエラー出ないようにする定型文----
    public static U_Life instance;

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
        life_count = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (life_count == 3) 
        {
            LifeArray[2].gameObject.SetActive(true);
            LifeArray[1].gameObject.SetActive(true);
            LifeArray[0].gameObject.SetActive(true);
        }
        if (life_count == 2)
        {
            LifeArray[2].gameObject.SetActive(false);
            LifeArray[1].gameObject.SetActive(true);
            LifeArray[0].gameObject.SetActive(true);
        }
        if (life_count == 1)
        {
            LifeArray[2].gameObject.SetActive(false);
            LifeArray[1].gameObject.SetActive(false);
            LifeArray[0].gameObject.SetActive(true);
        }
        if (life_count == 0)
        {
            LifeArray[2].gameObject.SetActive(false);
            LifeArray[1].gameObject.SetActive(false);
            LifeArray[0].gameObject.SetActive(false);

            SceneManager.LoadScene("Game_over");
        }
    }
}
