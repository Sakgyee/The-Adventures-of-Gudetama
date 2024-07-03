using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugunghwaFlower : MonoBehaviour
{
    public static MugunghwaFlower instance;
    public ParticleSystem particleObject; //파티클시스템
    public GameObject gameover;
    public Transform player;
    public Sprite[] Kuromi;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    public AudioSource mugung4;
    public AudioSource mugung3;
    public AudioSource mugung2;
    public AudioSource mugung1;
    public AudioSource mugungGun;
    public AudioSource die;
    public AudioSource gameOver;
    int sprite_index;

    private Vector3 playerPositionAtLookSection;
    int MoveCheck = 0;

    void Awake()
    {
        MugunghwaFlower.instance = this; //변수 초기화부
    }
    void Start()
    {       
        sprite_index = 0;        
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Mugung());
    }
    public void kuromidie()
    {
        audioSource.Stop();
        audioSource = die;
        audioSource.Play();
        this.gameObject.SetActive(false);
    }

    IEnumerator Mugung()
    {
        while (true)
        {
            int randomPattern = Random.Range(1, 5);
            int randomLook = Random.Range(1, 6);
            switch (randomPattern)
            {
                case 1:
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    spriteRenderer.sprite = Kuromi[0];
                    audioSource = mugung1;
                    audioSource.Play();
                    yield return new WaitForSeconds(1.0f);
                    MoveCheck += 1;
                    spriteRenderer.sprite = Kuromi[1];                  
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    playerPositionAtLookSection = player.position;
                    yield return new WaitForSeconds(randomLook);
                    MoveCheck -= 1;
                    break;
                case 2:
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    spriteRenderer.sprite = Kuromi[0];
                    audioSource = mugung2;
                    audioSource.Play();
                    yield return new WaitForSeconds(2.0f);
                    MoveCheck += 1;
                    spriteRenderer.sprite = Kuromi[1];
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    playerPositionAtLookSection = player.position;
                    yield return new WaitForSeconds(randomLook);
                    MoveCheck -= 1;
                    break;
                case 3:
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    spriteRenderer.sprite = Kuromi[0];
                    audioSource = mugung3;
                    audioSource.Play();
                    yield return new WaitForSeconds(3.0f);
                    MoveCheck += 1;
                    spriteRenderer.sprite = Kuromi[1];
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    playerPositionAtLookSection = player.position;
                    yield return new WaitForSeconds(randomLook);
                    MoveCheck -= 1;
                    break;
                case 4:
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    spriteRenderer.sprite = Kuromi[0];
                    audioSource = mugung4;
                    audioSource.Play();
                    yield return new WaitForSeconds(4.0f);
                    MoveCheck += 1;
                    spriteRenderer.sprite = Kuromi[1];
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    playerPositionAtLookSection = player.position;
                    yield return new WaitForSeconds(randomLook);
                    MoveCheck -= 1;
                    break;
            }        
        }
        
    }      
    void Update()
    {
        if(MoveCheck == 1)
        {
            // Check if the player's position has changed since the last look section
            if (Vector3.Distance(player.position, playerPositionAtLookSection) > 0.1f)
            {
                audioSource = mugungGun;
                audioSource.Play();
                StartCoroutine(dead());
                // Player's position has changed, disable the player object               
                StartCoroutine(deadblood());
                MoveCheck -= 1;
            }
        }
        if(!this.gameObject)
        {
            audioSource.Stop();
        }
    }
    IEnumerator dead()
    {
        yield return new WaitForSeconds(0.5f);
        particleObject.Play();
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);      
        audioSource = gameOver;
        audioSource.Play();
        gameover.gameObject.SetActive(true);
    }
    IEnumerator deadblood()
    {
        yield return new WaitForSeconds(1.0f);
        particleObject.Stop();
    }
}
