using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJump : MonoBehaviour
{
    public Sprite[] SpringMotion;
    int sprite_index;
    SpriteRenderer spriteRenderer;

    public GameObject player;
    bool jumpzone = false;
    float jumpforce = 400f;
    public float jumpzoneforce = 2f;
    Rigidbody2D rigi;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Spring());
            jumpzone = true;
        }
    }
    void Start()
    {
        sprite_index = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Springjump();
    }
    void Springjump()
    {
        if (jumpzone == true)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpzoneforce) *jumpforce);
            jumpzone = false;
        }
    }
    IEnumerator Spring()
    {
        spriteRenderer.sprite = SpringMotion[1];
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.sprite = SpringMotion[0];
    }
}
