using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    AudioSource audioSource;
    public AudioSource rainshotSound;
    public AudioSource boltshotSound;
    public AudioSource rushSound;
    public AudioSource shotposSound;
    public AudioSource groggySound;
    public AudioSource angrySound;
    public AudioSource bubbleSound;
    public AudioSource teleSound;
    public AudioSource pase2Pattern;

    public static Boss instance; //변수 선언부

    public float rightwardForce = 15.0f;
    public float leftwardForce = 15.0f;
    public float upwardForce = 20.0f;
    public float downwardForce = 20.0f;
    
    // 1페이즈
    private Coroutine boltshotCoroutine;
    private Coroutine rainshotCoroutine;
    private Coroutine rushCoroutine;
    private Coroutine chooseAndRunPatternCoroutine;
    private Coroutine GroggyCoroutine;
    private bool shouldCoinRainContinue = true;
    private bool shouldGroggyContinue = true;
    /*
    // 2페이즈
    private Coroutine boltshotCoroutine;
    private Coroutine rainshotCoroutine;
    private Coroutine rushCoroutine;
    private Coroutine chooseAndRunPatternCoroutine;
    */

    Rigidbody2D rigi;
    Animator anim;
    float PatternTime = 0;
    // 패턴 1 rainshot
    //랜덤으로 생성 할 오브젝트
    public GameObject Coin;

    public float bulletDmg = 1f;
    public float bossmaxhp = 500f;
    public float bossnowhp = 0;
    public GameObject hpbar;
    public Image nowhpbar;
    // 패턴 2 boltshot
    float PatternTimer = 10.0f;
    public GameObject boltLprefab; // 볼트왼쪽 프리팹
    public GameObject boltRprefab; // 볼트오른쪽 프리팹
    public GameObject platform; // 패턴 발판
    public GameObject onejump1;
    // 볼트 포대
    public GameObject shotPos1;
    public GameObject shotPos2;
    public GameObject shotPos3;
    public GameObject shotPos4;
    // 볼트 발사위치
    public Transform shotpos1;
    public Transform shotpos2;
    public Transform shotpos3;
    public Transform shotpos4;

    // 패턴 3 rush
    public GameObject Line1;
    public GameObject Line2;
    public GameObject Line3;
    public GameObject Line4;
    public GameObject Line5;
    public GameObject Line6;
    public GameObject Line7;

    public GameObject bossfall;
    // 러쉬1
    Vector2 target = new Vector2(0, 0.5f);
    Vector2 target1 = new Vector2(-14f, 0.5f);
    float rush1 = 0;

    // 러쉬2
    Vector2 target2 = new Vector2(0, 0.5f);
    Vector2 target3 = new Vector2(14f, 0.5f);
    float rush2 = 0;

    // 러쉬3
    public GameObject oj1;
    public GameObject oj2;

    Vector2 target4 = new Vector2(0, -0.7f);
    Vector2 target5 = new Vector2(-8f, -0.7f);
    Vector2 target6 = new Vector2(8, -0.7f);
    float rush3 = 0;

    //2페이즈
    public GameObject PlatOff;
    public GameObject PlatOff1;
    public GameObject CircleOn;
    public GameObject Line2p1;
    public GameObject Line2p2;
    public GameObject Line2pCircle;
    public GameObject OJ2ps;

    // 볼트 포대
    public GameObject shotPos2PL;
    public GameObject shotPos2PR;
    public GameObject shotPos2PLD;
    public GameObject shotPos2PRD;
    public GameObject shotPos2PDO;
    // 볼트 발사위치
    public Transform shotpos2PL;
    public Transform shotpos2PR;
    public Transform shotpos2PLD;
    public Transform shotpos2PRD;
    public Transform shotpos2PDO;

    public GameObject boltL2Pprefab; // 볼트왼쪽 프리팹
    public GameObject boltR2Pprefab; // 볼트오른쪽 프리팹
    public GameObject boltLD2Pprefab; // 볼트왼쪽대각선 프리팹
    public GameObject boltRD2Pprefab; // 볼트오른쪽대각선 프리팹
    public GameObject boltDO2Pprefab; // 볼트아래쪽 프리팹

    //움직이는 원
    public GameObject CircleMove;
    Vector2 TG = new Vector2(-5f, 0f);
    Vector2 TG1 = new Vector2(-5f, 5f);
    Vector2 TG2 = new Vector2(5f, 0f);
    Vector2 TG3 = new Vector2(5f, 5f);
    Vector2 TG4 = new Vector2(0f, 5f);
    Vector2 TG5 = new Vector2(0f, 0f);
    float CirclemoveCount = 0;
    void Awake()
    {
        Boss.instance = this; //변수 초기화부
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    IEnumerator boltshot()
    {

        anim.SetTrigger("doTele");
        audioSource = teleSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector2(7f, 3f);
        yield return new WaitForSeconds(0.4f);
        anim.SetTrigger("doBoltShot");
        audioSource = boltshotSound;
        audioSource.Play();


        platform.gameObject.SetActive(true);
        onejump1.gameObject.SetActive(true);
        Debug.Log("boltshot");        
        PatternTimer = 10;

        yield return new WaitForSeconds(1.0f);
        while (PatternTimer > 0f)
        {

            Debug.Log(PatternTimer);
            
            int randomShot = Random.Range(1, 5);
            Debug.Log(randomShot);
            if (randomShot == 1)
            {
                boltRprefab.SetActive(true);
                shotPos1.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltR = Instantiate(boltRprefab) as GameObject;
                // bolt의 위치를 shotpos로 이동
                boltR.transform.position = shotpos1.transform.position;
                // bolt에 Rigidbody값을 가져와서 AddForce로 발사
                boltR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rightwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);

                shotPos1.SetActive(false);
                boltRprefab.SetActive(false);
            }
            if (randomShot == 2)
            {
                boltRprefab.SetActive(true);
                shotPos2.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltR = Instantiate(boltRprefab) as GameObject;
                // bolt의 위치를 shotpos로 이동
                boltR.transform.position = shotpos2.transform.position;
                // bolt에 Rigidbody값을 가져와서 AddForce로 발사
                boltR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rightwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);
                shotPos2.SetActive(false);
                boltRprefab.SetActive(false);
            }
            if (randomShot == 3)
            {
                boltLprefab.SetActive(true);
                shotPos3.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltL = Instantiate(boltLprefab) as GameObject;
                // bolt의 위치를 shotpos로 이동
                boltL.transform.position = shotpos3.transform.position;
                // bolt에 Rigidbody값을 가져와서 AddForce로 발사
                boltL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * leftwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);
                shotPos3.SetActive(false);
                boltLprefab.SetActive(false);
            }
            if (randomShot == 4)
            {
                boltLprefab.SetActive(true);
                shotPos4.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltL = Instantiate(boltLprefab) as GameObject;
                // bolt의 위치를 shotpos로 이동
                boltL.transform.position = shotpos4.transform.position;
                // bolt에 Rigidbody값을 가져와서 AddForce로 발사
                boltL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * leftwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);
                shotPos4.SetActive(false);
                boltLprefab.SetActive(false);
            }
            yield return new WaitForSeconds(0.5f);
            PatternTimer -= 1;
        }
        platform.gameObject.SetActive(false);
        onejump1.gameObject.SetActive(false);
        oj1.SetActive(false);
        oj2.SetActive(false);
        OJ2ps.SetActive(false);

        anim.SetTrigger("Idle");
        yield return null;
    }

    IEnumerator rainshot()
    {
        Debug.Log("rainshot");

        anim.SetTrigger("doTele");
        audioSource = teleSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector2(-7f, 3f);
        yield return new WaitForSeconds(0.4f);      
        anim.SetTrigger("doRainShot");
        audioSource = rainshotSound;
        audioSource.Play();
        StartCoroutine(coinrain(15.0f));
        yield return new WaitForSeconds(15.0f);
        anim.SetTrigger("Idle");
        yield return null;

        onejump1.gameObject.SetActive(false);
        oj1.SetActive(false);
        oj2.SetActive(false);
        OJ2ps.SetActive(false);
    }

    IEnumerator rush()
    {
        Debug.Log("rush");

        anim.SetTrigger("doTele");
        audioSource = teleSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector2(0f, 4f);
        yield return new WaitForSeconds(0.4f);
        anim.SetTrigger("doRush");
        yield return new WaitForSeconds(0.5f);
        // 러쉬1
        Line1.gameObject.SetActive(true);

        anim.SetTrigger("doTele");
        audioSource = teleSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector2(0f, 9f);
        yield return new WaitForSeconds(0.4f);
        anim.SetTrigger("doRush");       
        yield return new WaitForSeconds(1.5f);
        Line1.gameObject.SetActive(false);
        audioSource = rushSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        bossfall.gameObject.SetActive(true);
        rigi.AddForce(Vector2.down * downwardForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2.0f);
        rigi.velocity = Vector2.zero;
        bossfall.gameObject.SetActive(false);
        // 러쉬2
        onejump1.gameObject.SetActive(true);

        Line2.gameObject.SetActive(true);
        transform.position = new Vector2(-11.5f, -2.3f);       
        yield return new WaitForSeconds(1.5f);
        Line2.gameObject.SetActive(false);
        audioSource = rushSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        rigi.AddForce(Vector2.right * rightwardForce, ForceMode2D.Impulse);       
        yield return new WaitForSeconds(2.0f);
        rigi.velocity = Vector2.zero;

        // 러쉬3
        Line2.gameObject.SetActive(true);
        transform.position = new Vector2(11.5f, -2.3f);        
        yield return new WaitForSeconds(1.5f);
        Line2.gameObject.SetActive(false);
        audioSource = rushSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        rigi.AddForce(Vector2.left * leftwardForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2.0f);
        rigi.velocity = Vector2.zero;

        onejump1.gameObject.SetActive(false);

        // 러쉬4
        Line3.gameObject.SetActive(true);
        transform.position = new Vector2(-14f, 0.3f);
        transform.localScale = new Vector2(13.5f, 13.5f);

        yield return new WaitForSeconds(1.5f);
        Line3.gameObject.SetActive(false);
        audioSource = rushSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        rush1 += 1;
        
        yield return new WaitForSeconds(0.5f);
        audioSource = rushSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        rush1 += 1;
       
        yield return new WaitForSeconds(3.0f);
        rush1 -= 2;
        transform.localScale = new Vector2(3, 3f);

        // 러쉬5
        Line4.gameObject.SetActive(true);
        transform.position = new Vector2(14f, 0.3f);
        transform.localScale = new Vector2(13.5f, 13.5f);

        yield return new WaitForSeconds(2.0f);
        Line4.gameObject.SetActive(false);
        audioSource = rushSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        rush2 += 1;

        yield return new WaitForSeconds(0.5f);
        audioSource = rushSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        rush2 += 1;
        yield return new WaitForSeconds(3.0f);
        rush2 -= 2;
        transform.localScale = new Vector2(3, 3f);
        
        // 러쉬6
        Line5.gameObject.SetActive(true);
        transform.position = new Vector2(0f, -10f);
        transform.localScale = new Vector2(12f, 10f);

        yield return new WaitForSeconds(1.5f);
        Line5.gameObject.SetActive(false);
        audioSource = rushSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        rush3 += 1;

        yield return new WaitForSeconds(1.0f);
        Line6.gameObject.SetActive(true);
        oj1.gameObject.SetActive(true);
        oj2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Line6.gameObject.SetActive(false);
        audioSource = rushSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        rush3 += 1;
        yield return new WaitForSeconds(2.0f);
        Line7.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Line7.gameObject.SetActive(false);
        audioSource = rushSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        rush3 += 1;
        yield return new WaitForSeconds(4.0f);
        oj1.gameObject.SetActive(false);
        oj2.gameObject.SetActive(false);
        rush3 -= 3;

        anim.SetTrigger("doTele");
        audioSource = teleSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        transform.localScale = new Vector2(3, 3f);
        yield return new WaitForSeconds(0.4f);       
        anim.SetTrigger("Idle");

        yield return null;

        onejump1.gameObject.SetActive(false);
        oj1.SetActive(false);
        oj2.SetActive(false);
        OJ2ps.SetActive(false);
    }

    //2페이즈
    IEnumerator Sans()
    {
        onejump1.gameObject.SetActive(false);
        oj1.SetActive(false);
        oj2.SetActive(false);
        OJ2ps.SetActive(false);

        PatternTimer = 10;

        anim.SetTrigger("doTele");
        audioSource = teleSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector2(0f, 5f);
        yield return new WaitForSeconds(0.4f);
        anim.SetTrigger("2pIdle");

        Line2p1.gameObject.SetActive(true);
        Line2p2.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        Line2p1.gameObject.SetActive(false);
        Line2p2.gameObject.SetActive(false);
        PlatOff.gameObject.SetActive(false);

        anim.SetTrigger("doTele");
        audioSource = teleSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector2(0f, 10f);
        yield return new WaitForSeconds(0.4f);
        anim.SetTrigger("2pIdle");
        audioSource = pase2Pattern;
        audioSource.Play();
        CircleOn.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);


        for (int i = 0; i < 10; i++)
        {

            Debug.Log("i: " + i);
            
            if (i == 0)
            {
          
                // 첫번째 샷 R
                boltR2Pprefab.SetActive(true);

                shotPos2PR.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltR = Instantiate(boltR2Pprefab) as GameObject;

                // boltR의 위치를 shotpos로 이동
                boltR.transform.position = shotpos2PR.transform.position;

                // boltR에 Rigidbody값을 가져와서 AddForce로 발사
                boltR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rightwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);

                shotPos2PR.SetActive(false);

                boltR2Pprefab.SetActive(false);
                
            }
            if (i == 1)
            {
                
                // 두번째 샷 L
                boltL2Pprefab.SetActive(true);
                shotPos2PL.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltL = Instantiate(boltL2Pprefab) as GameObject;

                // boltL의 위치를 shotpos로 이동
                boltL.transform.position = shotpos2PL.transform.position;

                // boltL에 Rigidbody값을 가져와서 AddForce로 발사
                boltL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * leftwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);

                shotPos2PL.SetActive(false);

                boltL2Pprefab.SetActive(false);

            }
            if (i == 2)
            {
              
                // 세번째 샷 R, LD                
                boltR2Pprefab.SetActive(true);
                boltLD2Pprefab.SetActive(true);

                shotPos2PR.SetActive(true);                
                shotPos2PLD.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltR = Instantiate(boltR2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltLD = Instantiate(boltLD2Pprefab) as GameObject;

                // boltR의 위치를 shotpos로 이동
                boltR.transform.position = shotpos2PR.transform.position;
                // boltLD를 40도 회전시킨다.
                boltLD.transform.rotation = Quaternion.Euler(0f, 180f, -40f);
                // boltLD의 위치를 shotpos로 이동
                boltLD.transform.position = shotpos2PLD.transform.position;

                // boltR에 Rigidbody값을 가져와서 AddForce로 발사
                boltR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rightwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltLD에 Rigidbody값을 가져와서 AddForce로 발사
                boltLD.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, -10), ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);

                shotPos2PR.SetActive(false);
                shotPos2PLD.SetActive(false);

                boltR2Pprefab.SetActive(false);
                boltLD2Pprefab.SetActive(false);
                
            }
            if (i == 3)
            {
     
                // 네번째 샷 LD, RD                
                boltLD2Pprefab.SetActive(true);
                boltRD2Pprefab.SetActive(true);

                shotPos2PLD.SetActive(true);
                shotPos2PRD.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltLD = Instantiate(boltLD2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltRD = Instantiate(boltRD2Pprefab) as GameObject;
                
                // boltLD를 40도 회전시킨다.
                boltLD.transform.rotation = Quaternion.Euler(0f, 180f, -40f);
                // boltLD의 위치를 shotpos로 이동
                boltLD.transform.position = shotpos2PLD.transform.position;
                // boltRD를 40도 회전시킨다.
                boltRD.transform.rotation = Quaternion.Euler(0f, 0f, -40f);
                // boltRD의 위치를 shotpos로 이동
                boltRD.transform.position = shotpos2PRD.transform.position;

                // boltLD에 Rigidbody값을 가져와서 AddForce로 발사
                boltLD.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, -10), ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltRD에 Rigidbody값을 가져와서 AddForce로 발사
                boltRD.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, -10), ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);

                shotPos2PLD.SetActive(false);
                shotPos2PRD.SetActive(false);

                boltLD2Pprefab.SetActive(false);
                boltRD2Pprefab.SetActive(false);

            }
            if (i == 4)
            {
             
                // 다섯번째 샷 L, R, DO
                boltL2Pprefab.SetActive(true);
                boltR2Pprefab.SetActive(true);
                boltDO2Pprefab.SetActive(true);

                shotPos2PL.SetActive(true);
                shotPos2PR.SetActive(true);                
                shotPos2PDO.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltL = Instantiate(boltL2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltR = Instantiate(boltR2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltDO = Instantiate(boltDO2Pprefab) as GameObject;

                // boltL의 위치를 shotpos로 이동
                boltL.transform.position = shotpos2PL.transform.position;
                // boltR의 위치를 shotpos로 이동
                boltR.transform.position = shotpos2PR.transform.position;
                // boltDO를 아래방향으로 회전
                boltDO.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                // boltDO의 위치를 shotpos로 이동
                boltDO.transform.position = shotpos2PDO.transform.position;

                // boltL에 Rigidbody값을 가져와서 AddForce로 발사
                boltL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * leftwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltR에 Rigidbody값을 가져와서 AddForce로 발사
                boltR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rightwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltDO에 Rigidbody값을 가져와서 AddForce로 발사
                boltDO.GetComponent<Rigidbody2D>().AddForce(Vector2.down * downwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);

                shotPos2PL.SetActive(false);
                shotPos2PR.SetActive(false);
                shotPos2PDO.SetActive(false);

                boltL2Pprefab.SetActive(false);
                boltR2Pprefab.SetActive(false);
                boltDO2Pprefab.SetActive(false);

            }
            if (i == 5)
            {
        
                // 여섯번째 샷 L, RD
                boltL2Pprefab.SetActive(true);
                boltRD2Pprefab.SetActive(true);

                shotPos2PL.SetActive(true);
                shotPos2PRD.SetActive(true);
                yield return new WaitForSeconds(1.2f);
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltL = Instantiate(boltL2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltRD = Instantiate(boltRD2Pprefab) as GameObject;

                // boltL의 위치를 shotpos로 이동
                boltL.transform.position = shotpos2PL.transform.position;
                // boltRD를 40도 회전시킨다.
                boltRD.transform.rotation = Quaternion.Euler(0f, 0f, -40f);
                // boltRD의 위치를 shotpos로 이동
                boltRD.transform.position = shotpos2PRD.transform.position;

                // bolt에 Rigidbody값을 가져와서 AddForce로 발사
                boltL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * leftwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // bolt에 Rigidbody값을 가져와서 AddForce로 발사
                boltRD.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, -10), ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);

                shotPos2PL.SetActive(false);
                shotPos2PRD.SetActive(false);

                boltL2Pprefab.SetActive(false);
                boltRD2Pprefab.SetActive(false);

            }
            if (i == 6)
            {
               
                // 일곱번째 샷 LD, RD, DO
                boltLD2Pprefab.SetActive(true);
                boltRD2Pprefab.SetActive(true);
                boltDO2Pprefab.SetActive(true);

                shotPos2PLD.SetActive(true);              
                shotPos2PRD.SetActive(true);
                shotPos2PDO.SetActive(true);
                yield return new WaitForSeconds(1.2f);

                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltLD = Instantiate(boltLD2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltRD = Instantiate(boltRD2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltDO = Instantiate(boltDO2Pprefab) as GameObject;

                // boltLD를 40도 회전시킨다.
                boltLD.transform.rotation = Quaternion.Euler(0f, 180f, -40f);
                // boltLD의 위치를 shotpos로 이동
                boltLD.transform.position = shotpos2PLD.transform.position;
                // boltRD를 40도 회전시킨다.
                boltRD.transform.rotation = Quaternion.Euler(0f, 0f, -40f);
                // boltRD의 위치를 shotpos로 이동
                boltRD.transform.position = shotpos2PRD.transform.position;
                // boltDO를 아래방향으로 회전
                boltDO.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                // boltDO의 위치를 shotpos로 이동
                boltDO.transform.position = shotpos2PDO.transform.position;

                // boltLD에 Rigidbody값을 가져와서 AddForce로 발사
                boltLD.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, -10), ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltRD에 Rigidbody값을 가져와서 AddForce로 발사
                boltRD.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, -10), ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltDO에 Rigidbody값을 가져와서 AddForce로 발사
                boltDO.GetComponent<Rigidbody2D>().AddForce(Vector2.down * downwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);

                shotPos2PLD.SetActive(false);
                shotPos2PRD.SetActive(false);
                shotPos2PDO.SetActive(false);

                boltLD2Pprefab.SetActive(false);
                boltRD2Pprefab.SetActive(false);
                boltDO2Pprefab.SetActive(false);

            }
            if (i == 7)
            {
               
                // 여덟번째 샷 L, R, LD, RD
                boltL2Pprefab.SetActive(true);
                boltR2Pprefab.SetActive(true);
                boltLD2Pprefab.SetActive(true);
                boltRD2Pprefab.SetActive(true);

                shotPos2PL.SetActive(true);
                shotPos2PR.SetActive(true);
                shotPos2PLD.SetActive(true);               
                shotPos2PRD.SetActive(true);
                yield return new WaitForSeconds(1.2f);

                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltL = Instantiate(boltL2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltR = Instantiate(boltR2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltLD = Instantiate(boltLD2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltRD = Instantiate(boltRD2Pprefab) as GameObject;

                // boltL의 위치를 shotpos로 이동
                boltL.transform.position = shotpos2PL.transform.position;
                // boltR의 위치를 shotpos로 이동
                boltR.transform.position = shotpos2PR.transform.position;
                // boltLD 를 40도 회전시킨다.
                boltLD.transform.rotation = Quaternion.Euler(0f, 180f, -40f);
                // boltLD의 위치를 shotpos로 이동
                boltLD.transform.position = shotpos2PLD.transform.position;
                // boltRD를 40도 회전시킨다.
                boltRD.transform.rotation = Quaternion.Euler(0f, 0f, -40f);
                // boltRD의 위치를 shotpos로 이동
                boltRD.transform.position = shotpos2PRD.transform.position;

                // boltL에 Rigidbody값을 가져와서 AddForce로 발사
                boltL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * leftwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltR에 Rigidbody값을 가져와서 AddForce로 발사
                boltR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rightwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltLD에 Rigidbody값을 가져와서 AddForce로 발사
                boltLD.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, -10), ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltLD에 Rigidbody값을 가져와서 AddForce로 발사
                boltRD.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, -10), ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);

                shotPos2PL.SetActive(false);
                shotPos2PR.SetActive(false);
                shotPos2PLD.SetActive(false);
                shotPos2PRD.SetActive(false);

                boltL2Pprefab.SetActive(false);
                boltR2Pprefab.SetActive(false);
                boltLD2Pprefab.SetActive(false);
                boltRD2Pprefab.SetActive(false);

            }
            if (i == 8)
            {                
                // 아홉번째 샷 L, R, LD, RD, DO
                boltL2Pprefab.SetActive(true);
                boltR2Pprefab.SetActive(true);
                boltLD2Pprefab.SetActive(true);
                boltRD2Pprefab.SetActive(true);
                boltDO2Pprefab.SetActive(true);

                shotPos2PL.SetActive(true);
                shotPos2PR.SetActive(true);
                shotPos2PLD.SetActive(true);
                shotPos2PRD.SetActive(true);
                shotPos2PDO.SetActive(true);
                yield return new WaitForSeconds(1.2f);

                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltL = Instantiate(boltL2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltR = Instantiate(boltR2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltLD = Instantiate(boltLD2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltRD = Instantiate(boltRD2Pprefab) as GameObject;
                // Instantiate(오브젝트)를 복제하고 bolt 게임오브젝트에 대입
                GameObject boltDO = Instantiate(boltDO2Pprefab) as GameObject;

                // boltL의 위치를 shotpos로 이동
                boltL.transform.position = shotpos2PL.transform.position;
                // boltR의 위치를 shotpos로 이동
                boltR.transform.position = shotpos2PR.transform.position;
                // boltLD 를 40도 회전시킨다.
                boltLD.transform.rotation = Quaternion.Euler(0f, 180f, -40f);
                // boltLD의 위치를 shotpos로 이동
                boltLD.transform.position = shotpos2PLD.transform.position;
                // boltRD를 40도 회전시킨다.
                boltRD.transform.rotation = Quaternion.Euler(0f, 0f, -40f);
                // boltRD의 위치를 shotpos로 이동
                boltRD.transform.position = shotpos2PRD.transform.position;
                // boltDO를 아래방향으로 회전
                boltDO.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                // boltDO의 위치를 shotpos로 이동
                boltDO.transform.position = shotpos2PDO.transform.position;

                // boltL에 Rigidbody값을 가져와서 AddForce로 발사
                boltL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * leftwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltR에 Rigidbody값을 가져와서 AddForce로 발사
                boltR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rightwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltLD에 Rigidbody값을 가져와서 AddForce로 발사
                boltLD.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, -10), ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltLD에 Rigidbody값을 가져와서 AddForce로 발사
                boltRD.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, -10), ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();
                // boltDO에 Rigidbody값을 가져와서 AddForce로 발사
                boltDO.GetComponent<Rigidbody2D>().AddForce(Vector2.down * downwardForce, ForceMode2D.Impulse);
                audioSource = shotposSound;
                audioSource.Play();

                yield return new WaitForSeconds(1.5f);

                shotPos2PL.SetActive(false);
                shotPos2PR.SetActive(false);
                shotPos2PLD.SetActive(false);
                shotPos2PRD.SetActive(false);
                shotPos2PDO.SetActive(false);

                boltL2Pprefab.SetActive(false);
                boltR2Pprefab.SetActive(false);
                boltLD2Pprefab.SetActive(false);
                boltRD2Pprefab.SetActive(false);
                boltDO2Pprefab.SetActive(false);
            }
            if(i == 9)
            {
                yield return new WaitForSeconds(1.0f);
                Line2pCircle.SetActive(true);
                oj1.SetActive(true);
                oj2.SetActive(true);
                OJ2ps.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                audioSource = pase2Pattern;
                audioSource.Play();
                Line2pCircle.SetActive(false);
                PlatOff1.SetActive(false);
                yield return new WaitForSeconds(1.5f);
                CirclemoveCount += 1;
                yield return new WaitForSeconds(3f);
                CirclemoveCount += 1;
                yield return new WaitForSeconds(1.5f);
                CirclemoveCount += 1;
                yield return new WaitForSeconds(2f);
                CirclemoveCount += 1;
                yield return new WaitForSeconds(1.5f);
                CirclemoveCount += 1;
                yield return new WaitForSeconds(2f);
                CirclemoveCount += 1;
                PlatOff1.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                oj1.SetActive(false);
                oj2.SetActive(false);
                OJ2ps.SetActive(false);
                CirclemoveCount = 0;
                yield return new WaitForSeconds(0.5f);
                CircleOn.SetActive(false);
                PlatOff.SetActive(true);
            }
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1.5f);

        onejump1.gameObject.SetActive(false);
        oj1.SetActive(false);
        oj2.SetActive(false);
        OJ2ps.SetActive(false);
    }

    IEnumerator Groggy(float Gduration)
    {
        onejump1.gameObject.SetActive(false);
        oj1.SetActive(false);
        oj2.SetActive(false);
        OJ2ps.SetActive(false);

        Debug.Log("groggy");       
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Vector2 newOffset = new Vector2(-0.05f, -0.2f); 
        boxCollider.offset = newOffset;       
        anim.SetTrigger("doTele");
        audioSource = teleSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector2(0f, -1.5f);
        yield return new WaitForSeconds(0.4f);
        if (bossnowhp > 125)
        {            
            anim.SetTrigger("doGroggy");
            StartCoroutine(groggysoundpop());
        }
        else if(bossnowhp <= 125)
        {
            anim.SetTrigger("2pGro");
            StartCoroutine(groggysoundpop());
        }
        yield return new WaitForSeconds(Gduration);

        newOffset = new Vector2(0f, 0.15f);
        boxCollider.offset = newOffset;

        anim.SetTrigger("doTele");
        audioSource = teleSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector2(0f, 2f);
        yield return new WaitForSeconds(0.4f);
        if (bossnowhp > 125)
        {
            anim.SetTrigger("Idle");
        }
        else if (bossnowhp <= 125)
        {
            anim.SetTrigger("2pIdle");
        }
        
        yield return null;
    }

    void Update()
    {
        nowhpbar.fillAmount = (float)bossnowhp / (float)bossmaxhp;
        if (bossnowhp <= 0)
        {
          
        }
        else if (bossnowhp == 125)
        {
            
        }

        if (rush1 == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 1f);
        }
        if (rush1 == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target1, 1f);
        }
        if (rush2 == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target2, 1f);
        }
        if (rush2 == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target3, 1f);
        }
        if (rush3 == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target4, 1f);
        }
        if (rush3 == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target5, 0.5f);
        }
        if (rush3 == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target6, 0.5f);
        }
        //2페 움직이는 원
        if (CirclemoveCount == 1)
        {
            CircleMove.transform.position = Vector2.MoveTowards(CircleMove.transform.position, TG, 0.005f);
        }
        if (CirclemoveCount == 2)
        {
            CircleMove.transform.position = Vector2.MoveTowards(CircleMove.transform.position, TG1, 0.01f);
        }
        if (CirclemoveCount == 3)
        {
            CircleMove.transform.position = Vector2.MoveTowards(CircleMove.transform.position, TG2, 0.01f);
        }
        if (CirclemoveCount == 4)
        {
            CircleMove.transform.position = Vector2.MoveTowards(CircleMove.transform.position, TG3, 0.005f);
        }
        if (CirclemoveCount == 5)
        {
            CircleMove.transform.position = Vector2.MoveTowards(CircleMove.transform.position, TG4, 0.01f);
        }
        if (CirclemoveCount == 6)
        {
            CircleMove.transform.position = Vector2.MoveTowards(CircleMove.transform.position, TG5, 0.01f);
        }
    }
    void Start()
    {
        oj1.SetActive(false);
        oj2.SetActive(false);
        OJ2ps.SetActive(false);
        onejump1.gameObject.SetActive(false);

        Debug.Log("start");
        bossnowhp = bossmaxhp;
        chooseAndRunPatternCoroutine = StartCoroutine(ChooseAndRunPattern());

        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator ChooseAndRunPattern()
    {

        yield return new WaitForSeconds(3.0f);


        // Run the coroutine based on the randomly chosen pattern
        while (true)
        {
            if (bossnowhp > 125)
            {
                // Pick a random pattern
                int randomPattern = Random.Range(1, 4);
                switch (randomPattern)
                {
                    case 1:
                        boltshotCoroutine = StartCoroutine(boltshot());
                        PatternTime += 1;
                        break;
                    case 2:
                        rainshotCoroutine = StartCoroutine(rainshot());
                        PatternTime += 2;
                        break;
                    case 3:
                        rushCoroutine = StartCoroutine(rush());
                        PatternTime += 3;
                        break;
                }
            }
            else if(bossnowhp <= 125)
            {
                // Pick a random pattern
                int randomPattern = Random.Range(1, 2);
                switch (randomPattern)
                {
                    case 1:
                        Debug.Log("startsans");
                        StartCoroutine(Sans());
                        break;
                    case 2:
                        //rainshotCoroutine = StartCoroutine(rainshot());
                        break;
                    case 3:
                        //rushCoroutine = StartCoroutine(rush());
                        //PatternTime += 3;
                        break;
                    case 4:
                        //StartCoroutine(spit());
                        break;
                }
            }

            if(bossnowhp > 125 && shouldGroggyContinue)
            {
                // 패턴 시간을 계산해서 그로기 타이밍을 맞춤
                if (PatternTime == 1)
                {
                    yield return new WaitForSeconds(34f);
                    PatternTime -= 1;
                    GroggyCoroutine = StartCoroutine(Groggy(10f));
                    
                }
                else if (PatternTime == 2)
                {
                    yield return new WaitForSeconds(16f);
                    GroggyCoroutine = StartCoroutine(Groggy(10f));
                }
                else if(PatternTime == 3)
                {
                    yield return new WaitForSeconds(40f);
                    PatternTime -= 3;
                    GroggyCoroutine = StartCoroutine(Groggy(10f));
                }
                
            }
               else if(bossnowhp <= 125 && !shouldGroggyContinue)
            {
                yield return new WaitForSeconds(52f);
                GroggyCoroutine = StartCoroutine(Groggy(20f));
            }

            // 그로기 몇초 줄건지
            if (bossnowhp > 125 && shouldGroggyContinue)
            {
                yield return new WaitForSeconds(15f);
            }
            else if (bossnowhp <= 125 && !shouldGroggyContinue)
            {
                yield return new WaitForSeconds(25f);
                
            }
        }

    }

    IEnumerator coinrain(float duration)
    {
        float timer = 0f;
        int numberOfCoins = 10;
        while (timer < duration && shouldCoinRainContinue)
        {
            for (int i = 0; i < numberOfCoins; i++)
            {
                CreateCoin();
            }
            yield return new WaitForSeconds(1.0f);
            timer += 1.0f;
        }
    }
    public void CreateCoin()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(1.1f, 2.1f), 0));
        pos.z = 0.0f;
        Instantiate(Coin, pos, Quaternion.identity);
    }

    IEnumerator Hp125()
    {
        anim.SetTrigger("doTele");
        audioSource = teleSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector2(0f, 0f);
        yield return new WaitForSeconds(0.4f);
        anim.SetTrigger("2pIdle");

    }
    IEnumerator groggysoundpop()
    {
        audioSource = groggySound;
        audioSource.Play();
        yield return new WaitForSeconds(7.0f);
        audioSource = bubbleSound;
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            bossnowhp -= bulletDmg;
            Debug.Log(bossnowhp);
            if (bossnowhp == 125) // 반피 2페이즈
            {
                rigi.velocity = Vector2.zero;
                transform.localScale = new Vector2(3.0f, 3.0f);
                audioSource = angrySound;
                audioSource.Play();
                StopCoroutines1p();
                StartCoroutine(Hp125());
                //2페 변신 애니메이션 들어갈 곳
                StartCoroutine(ChooseAndRunPattern());
                //this.gameObject.SetActive(false);

            }
            if (bossnowhp <= 0) // 적 사망
            {
                // 사망 애니메이션 들어갈 곳
                gameObject.SetActive(false);
                hpbar.gameObject.SetActive(false);
            }
        }
    }
    private void StopCoroutines1p()
    {
        
        if (boltshotCoroutine != null)
            StopCoroutine(boltshotCoroutine);

        if (rainshotCoroutine != null)
            StopCoroutine(rainshotCoroutine);

        if (rushCoroutine != null)
            StopCoroutine(rushCoroutine);

        if (chooseAndRunPatternCoroutine != null)
            StopCoroutine(chooseAndRunPatternCoroutine);
        if(GroggyCoroutine != null)
        {
            StopCoroutine(GroggyCoroutine);
        }

        shouldCoinRainContinue = false;
        shouldGroggyContinue = false;

        platform.gameObject.SetActive(false);
        onejump1.gameObject.SetActive(false);
        shotPos1.SetActive(false);
        shotPos2.SetActive(false);
        shotPos3.SetActive(false);
        shotPos4.SetActive(false);
        boltRprefab.SetActive(false);
        boltLprefab.SetActive(false);
        Coin.SetActive(false);
        Line1.SetActive(false);
        Line2.SetActive(false);
        Line3.SetActive(false);
        Line4.SetActive(false);
        Line5.SetActive(false);
        Line6.SetActive(false);
        Line7.SetActive(false);
        bossfall.SetActive(false);       
        oj1.SetActive(false);
        oj2.SetActive(false);
    }
}
