using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsEvent : MonoBehaviour
{
    private float spawnTime; //총알 생성시간
    //private float lifetime = 2f;  // 총알 수명 (초)
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
            // 미사일의 수명이 다 되면 삭제
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
