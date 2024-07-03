using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject clone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Wall1.SetActive(false);
        }
        if (collision.CompareTag("PlayerClone"))
        {
            Wall2.SetActive(false);
            clone.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
