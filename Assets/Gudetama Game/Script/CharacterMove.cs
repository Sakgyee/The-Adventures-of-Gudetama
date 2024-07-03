using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    float moveX;
    public float PlayerSpeed; //플레이어 속도
    Rigidbody2D rigi; //리지드바디 선언

    public List<GameObject> oneJumpReList = new List<GameObject>();
    public float jumpForce = 5f;
    public float jumpDuration = 3f;
    private bool isJumping = false;
    private float jumpStartTime;
    public bool isGrounded;
    public float groundCheckDistance = 0.5f;
    public LayerMask groundLayer;

    public float diagonalOffset = 0.5f; //Offset value for the diagonal raycasts

    private bool isOnRope = false;

    //private Animator animator;
    //private BoxCollider2D boxCollider;
    //static public CharacterMove instance;
    void Start()
    {
        /*
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            boxCollider = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        */
        rigi = GetComponent<Rigidbody2D>(); // 현재 스크립트를 가지고 있는 오브젝트의 리지드바디 가져오기
        GameObject[] oneJumpReArray = GameObject.FindGameObjectsWithTag("onejump");
        oneJumpReList.AddRange(oneJumpReArray);
    }

    void PlayerMove()
    {
        // 플레이어 이동 구간 
        if (gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(PlayerSpeed * Time.deltaTime, 0, 0));
                transform.localScale = new Vector3(1f, 1f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-PlayerSpeed * Time.deltaTime, 0, 0));
                transform.localScale = new Vector3(-1f, 1f);
            }
            moveX = Input.GetAxis("Horizontal") * PlayerSpeed;
            rigi.velocity = new Vector2(moveX, rigi.velocity.y);
        }
        else if (gameObject.CompareTag("PlayerClone"))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //클론
                transform.Translate(new Vector3(-PlayerSpeed * Time.deltaTime, 0, 0));
                transform.localScale = new Vector3(-1f, 1f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //클론
                transform.Translate(new Vector3(PlayerSpeed * Time.deltaTime, 0, 0));
                transform.localScale = new Vector3(1f, 1f);
            }
            moveX = Input.GetAxis("Horizontal") * -PlayerSpeed;
            rigi.velocity = new Vector2(moveX, rigi.velocity.y);
        }    
        
    }
    void PlayerJump()
    {
        if(this.gameObject.layer == 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Jump();
                AudioSource jumpsound = GetComponent<AudioSource>();
                jumpsound.Play();
            }
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
            {
                Jump();
                AudioSource jumpsound = GetComponent<AudioSource>();
                jumpsound.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Z) && isJumping == true)
            {
                Jump();
                isJumping = false;
                AudioSource jumpsound = GetComponent<AudioSource>();
                jumpsound.Play();
            }
            if (Input.GetKey(KeyCode.Z) && isJumping && Time.time - jumpStartTime < jumpDuration)
            {
                JumpHigher();
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
        // 플레이어 점프 구간
        // Shoot raycasts to check for ground below and diagonally
        RaycastHit2D downHit = Physics2D.Raycast(rigi.position, Vector2.down, groundCheckDistance, groundLayer);
        //RaycastHit2D leftDiagonalHit = Physics2D.Raycast(rigi.position, (Vector2.down - Vector2.left).normalized + new Vector2(0, -diagonalOffset), groundCheckDistance, groundLayer);
        //RaycastHit2D rightDiagonalHit = Physics2D.Raycast(rigi.position, (Vector2.down - Vector2.right).normalized + new Vector2(0, -diagonalOffset), groundCheckDistance, groundLayer);

        // Check if any of the raycasts hit the ground
        isGrounded = downHit.collider != null; //|| leftDiagonalHit.collider != null || rightDiagonalHit.collider != null;
        
        // Landing Platform
        //Debug.DrawRay(rigi.position, (Vector2.down - Vector2.right).normalized + new Vector2(0, -diagonalOffset), new Color(0, 1, 0));
        //Debug.DrawRay(rigi.position, (Vector2.down - Vector2.left).normalized + new Vector2(0, -diagonalOffset), new Color(0, 1, 0));
        Debug.DrawRay(rigi.position, Vector2.down, new Color(0, 1, 0));

        /*
        // 시작,방향 색깔

        //빔에 맞았는지 
        isGrounded = Physics2D.Raycast(rigi.position, (Vector2.down - Vector2.right).normalized + new Vector2(0, -diagonalOffset), groundCheckDistance, groundLayer);
        isGrounded = Physics2D.Raycast(rigi.position, (Vector2.down - Vector2.left).normalized + new Vector2(0, -diagonalOffset), groundCheckDistance, groundLayer);
        isGrounded = Physics2D.Raycast(rigi.position, Vector2.down, groundCheckDistance, groundLayer);
        /*
            if (isGrounded.collider != null)
            {
                if (isGrounded.distance < 0.5f)
                {
                    Debug.Log(isGrounded.collider.name);
                }

            }     
        */

        

    }
    void FixedUpdate() //지속적인 키 입력
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigi.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //최대속도 
        if (rigi.velocity.x > PlayerSpeed)//오른쪽방향
        {
            rigi.velocity = new Vector2(PlayerSpeed, rigi.velocity.y);//y값을 0으로 잡으면 공중에서 멈춰버림
        }
        else if (rigi.velocity.x < PlayerSpeed * (-1))//왼쪽방향
        {
            rigi.velocity = new Vector2(PlayerSpeed * (-1), rigi.velocity.y);
        }

    }

    private void Jump()
    {
        rigi.velocity = new Vector2(rigi.velocity.x, 0f); //이단점프 전 수직 속도 재설정
        rigi.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
        jumpStartTime = Time.time;
    }

    private void JumpHigher()
    {
        rigi.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (oneJumpReList.Contains(collision.gameObject))
        {
            isJumping = true;
            StartCoroutine(onejumpre(collision.gameObject));
        }
        if (collision.CompareTag("Rope"))
        {
            rigi.velocity = Vector2.zero;
            isOnRope = true;
            rigi.gravityScale = 0f;
            this.gameObject.layer = 0;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rope"))
        {
            isOnRope = false;
            rigi.gravityScale = 1.5f;
            this.gameObject.layer = 3;
        }
    }
    IEnumerator onejumpre(GameObject oneJumpReObject)
    {
        oneJumpReObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        oneJumpReObject.SetActive(true);
    }
 
}
