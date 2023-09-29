using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Laser : MonoBehaviour
{
    private float time;
    Rigidbody rb;
    public GameObject player;
    Vector3 mass;
    // public float acc;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("attack", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //var force = acc * E_attack.instance.dir;
        //rb.AddForce(force, ForceMode.Acceleration);
        //rb.AddForce(force);
        //Destroy(gameObject, 10f);
    }

    void attack()
    {
        mass = E_attack.instance.dir;
        rb.AddForce(mass, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)//�R���C�_�[�@��
    {
        if (other.gameObject.tag == "Player")//�Փ˂����炻��̓v���C���[������
        {
            U_Life.instance.life_count--;//���C�t���炷
            Debug.Log("�G�U���F��������");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "shot")
        {
            Destroy(gameObject);//�n�ʂɐG������
        }
    }
}
