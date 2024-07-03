using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    // �Ѿ� ������
    public GameObject Bulletsprefab;

    // �ִ� ���ÿ� ������ �� �ִ� �Ѿ� ����
    public int maxBullets = 5;
    // ���� �����ϴ� �Ѿ� ����
    public int currentBulletsCount = 0;
    // �Ѿ��� �߻�Ǵ� ������ �ӵ�
    public float launchSpeed = 10.0f;

    public static Bullets instance; //���� �����

    Rigidbody2D rb;

    AudioSource audioSource;
    public AudioSource shootingsound; 

    void Awake()
    {
        Bullets.instance = this; //���� �ʱ�ȭ��
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
            // �÷��̾ X ��ư�� ������
            if (Input.GetKeyDown(KeyCode.X))
            {
                //���� �Ѿ� ������ �ƽ��Ѿ� �������� ��
                if (currentBulletsCount < maxBullets)
                {              
                    // ���������κ��� ���ο� �̻��� ���� ������Ʈ ����
                    GameObject Bullets = Instantiate(Bulletsprefab, transform.position, transform.rotation);

                    // �Ѿ��� ������ٵ� 2D ������Ʈ ������
                    Rigidbody2D rb = Bullets.GetComponent<Rigidbody2D>();

                    // �Ѿ��� �÷��̾ �ٶ󺸴� �������� �߻�
                    Vector3 firingDirection = (transform.localScale.x < 0f) ? Vector3.left : Vector3.right;
                    rb.AddForce(firingDirection * launchSpeed, ForceMode2D.Impulse);

                audioSource = shootingsound;
                audioSource.Play();

                //�Ѿ� ī��Ʈ�� �ϳ� �ø���
                if (currentBulletsCount <= 5)
                {
                    currentBulletsCount++;
                }
            }
        }
        
        
    }
    public void BulletDestroyed()
    {
        // �Ѿ� ī��Ʈ�� 0���� ũ�� �Ѿ� ī��Ʈ�� �ϳ� ����     
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