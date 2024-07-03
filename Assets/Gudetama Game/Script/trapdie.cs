using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapdie: MonoBehaviour
{
    public GameObject gameover;
    public GameObject Coin;
    public GameObject Player;
    public GameObject PlayerClone;
    public string MapName;
    //public bool playAura = true; //파티클 제어 bool
    public ParticleSystem particleObject; //파티클시스템

    AudioSource audioSource;
    public AudioSource gameoverSound;
    public AudioSource hitSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
            StartCoroutine(HitPlayer());
            particleObject.Play();
            collision.gameObject.SetActive(false);
            gameover.gameObject.SetActive(true);            
            StartCoroutine(deadblood());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
            StartCoroutine(HitPlayer());            
            particleObject.Play();
            collision.gameObject.SetActive(false);
            if(MapName == "Main 3")
            {
                PlayerClone.gameObject.SetActive(false);
            }           
            gameover.gameObject.SetActive(true);           
            StartCoroutine(deadblood());
        }
        if (collision.gameObject.tag == "PlayerClone")
        {
            GameManager.instance.GameOver();
            StartCoroutine(HitPlayer());
            particleObject.Play();
            collision.gameObject.SetActive(false);
            Player.gameObject.SetActive(false);
            gameover.gameObject.SetActive(true);
            StartCoroutine(deadblood());
        }
        if (gameObject.tag == "Coin")
        {
            if (collision.gameObject.tag == "platte")
            {
                Destroy(gameObject);
            }
        }
        
    }
    IEnumerator HitPlayer()
    {
        audioSource = hitSound;
        audioSource.Play();
        yield return new WaitForSeconds(1f);      
    }

    IEnumerator deadblood()
    {      
        yield return new WaitForSeconds(1.0f);
        particleObject.Stop();
    }
}
