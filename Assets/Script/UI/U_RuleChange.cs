using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class U_RuleChange : MonoBehaviour
{
    private Image m_Image;
    private int pushKey = 0;
    private AudioSource audioSource;

    public AudioClip clickSE;
    public Sprite[] m_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int last = pushKey;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pushKey++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pushKey--;
        }

        pushKey = Math.Clamp(pushKey, 0, 3);
        if (pushKey != last) m_Image.sprite = m_Sprite[pushKey];
        //Aƒ{ƒ^ƒ“
        if (pushKey == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.PlayOneShot(clickSE);
                Invoke("GoMenu", 0.2f);
            }
        }
    }

    private void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
