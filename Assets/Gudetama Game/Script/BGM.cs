using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance;
    AudioSource audioSource;
    public AudioSource wind;
    public AudioSource strongwind;

    public int i = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        BGM.instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource = wind;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(i == 1)
        {
            audioSource.Stop();
            audioSource = strongwind;
            audioSource.Play();
            i -= 1;
        }
    }
}
