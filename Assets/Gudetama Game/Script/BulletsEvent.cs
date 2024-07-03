using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsEvent : MonoBehaviour
{
    private float spawnTime; //�Ѿ� �����ð�
    //private float lifetime = 2f;  // �Ѿ� ���� (��)
    public GameObject Player;

    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {    
        /*
        if(transform.position.x > 10.7f || transform.position.x < -10.7f)
        {
            Destroy(gameObject);
            Bullets.instance.BulletDestroyed();
        }
        /*
            // �̻����� ������ �� �Ǹ� ����
            if (Time.time - spawnTime > lifetime)
        {
            Destroy(gameObject);
            Bullets.instance.BulletDestroyed();           
        }      
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "save")
        {
            Destroy(gameObject);
            GameManager.instance.GameSave();
            Bullets.instance.BulletDestroyed();
        }  
        if(collision.gameObject.tag == "Boss")
        {
                Destroy(gameObject);
                Bullets.instance.BulletDestroyed();               
        }
        if(collision.gameObject.tag == "platte")
        {
            Destroy(gameObject);
            Bullets.instance.BulletDestroyed();
        }
        if (collision.gameObject.tag == "Switch")
        {
            Destroy(gameObject);
            Bullets.instance.BulletDestroyed();
        }
    }

}
