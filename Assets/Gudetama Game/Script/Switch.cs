using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite[] SwitchMotion;
    int sprite_index;
    SpriteRenderer spriteRenderer;
    int i = 0;
    AudioSource audioSource;
    public AudioSource switchOnOff;
    void Start()
    {
        sprite_index = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = SwitchMotion[0];

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            
            i++;
            
            if (i % 2 == 1) // È¦¼ö
            {
                audioSource = switchOnOff;
                audioSource.Play();
                spriteRenderer.sprite = SwitchMotion[1];
                WindController.instance.windDirection = new Vector2(-1f, 0f);            
            }
            else if (i % 2 == 0 && i != 0) //Â¦¼ö
            {
                audioSource = switchOnOff;
                audioSource.Play();
                spriteRenderer.sprite = SwitchMotion[2];
                WindController.instance.windDirection = new Vector2(1f, 0f);
            }
        }
    }

}
