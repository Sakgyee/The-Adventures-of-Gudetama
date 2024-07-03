using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    // 총알 프리팹
    public GameObject Bulletsprefab;

    // 최대 동시에 존재할 수 있는 총알 개수
    public int maxBullets = 5;
    // 현재 존재하는 총알 개수
    public int currentBulletsCount = 0;
    // 총알이 발사되는 순간의 속도
    public float launchSpeed = 10.0f;

    public static Bullets instance; //변수 선언부

    Rigidbody2D rb;

    AudioSource audioSource;
    public AudioSource shootingsound; 

    void Awake()
    {
        Bullets.instance = this; //변수 초기화부
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
            // 플레이어가 X 버튼을 누르면
            if (Input.GetKeyDown(KeyCode.X))
            {
                //현재 총알 개수가 맥스총알 개수보다 적
                if (currentBulletsCount < maxBullets)
                {              
                    // 프리팹으로부터 새로운 미사일 게임 오브젝트 생성
                    GameObject Bullets = Instantiate(Bulletsprefab, transform.position, transform.rotation);

                    // 총알의 리지드바디 2D 컴포넌트 가져옴
                    Rigidbody2D rb = Bullets.GetComponent<Rigidbody2D>();

                    // 총알을 플레이어가 바라보는 방향으로 발사
                    Vector3 firingDirection = (transform.localScale.x < 0f) ? Vector3.left : Vector3.right;
                    rb.AddForce(firingDirection * launchSpeed, ForceMode2D.Impulse);

                audioSource = shootingsound;
                audioSource.Play();

                //총알 카운트를 하나 올린다
                if (currentBulletsCount <= 5)
                {
                    currentBulletsCount++;
                }
            }
        }
        
        
    }
    public void BulletDestroyed()
    {
        // 총알 카운트가 0보다 크면 총알 카운트를 하나 뺀다     
        if(currentBulletsCount > 0)
        {
            currentBulletsCount--;
        }
    }
    public void ResetBullet()
    {
        currentBulletsCount = 0;
    }
}