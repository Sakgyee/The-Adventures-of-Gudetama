using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPosTele : MonoBehaviour
{
    Animator anim;
    AudioSource audioSource;
    public AudioSource postele;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();       
    }

    void OnEnable()
    {
        if (gameObject.CompareTag("1PsPos"))
        {
            StartCoroutine(shotpos());
        }
        if (gameObject.CompareTag("2PsPos"))
        {
                StartCoroutine(shotpos2Ps());
        }
    }
    IEnumerator shotpos()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetTrigger("PosTele");
        audioSource = postele;
        audioSource.Play();
        yield return new WaitForSeconds(2.0f);
        anim.SetTrigger("RePosTele");
        audioSource = postele;
        audioSource.Play();
       
    }
    IEnumerator shotpos2Ps()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetTrigger("2PsPosTele");
        audioSource = postele;
        audioSource.Play();
        yield return new WaitForSeconds(2.0f);
        anim.SetTrigger("2PsRePosTele");
        audioSource = postele;
        audioSource.Play();
    }

}
