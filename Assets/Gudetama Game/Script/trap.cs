using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    Rigidbody2D rigi;
    public float upwardForce = 20f;
    public float rightwardForce = 20f;
    public float leftwardForce = 20f;
    public List<GameObject> trapObjects = new List<GameObject>();
    public GameObject hide;
    public GameObject appear;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (GameObject trapObject in trapObjects)

                if (trapObject.CompareTag("fallingtrap"))
                {
                    trapObject.gameObject.SetActive(true);
                }

            foreach (GameObject trapObject in trapObjects)
                if (trapObject.CompareTag("fall"))
                {
                    hide.gameObject.SetActive(false);
                    appear.gameObject.SetActive(true);
                }

            foreach (GameObject trapObject in trapObjects)
                if (trapObject.CompareTag("xtrap1"))
                {
                    Rigidbody2D trapRigidbody = trapObject.GetComponent<Rigidbody2D>();
                    if (trapRigidbody != null)
                    {
                        trapRigidbody.AddForce(Vector2.right * rightwardForce, ForceMode2D.Impulse);                        
                    }                
                }

            foreach (GameObject trapObject in trapObjects)
                if (trapObject.CompareTag("ytrap1"))
            {
                Rigidbody2D trapRigidbody = trapObject.GetComponent<Rigidbody2D>();
                if (trapRigidbody != null)
                {
                    trapRigidbody.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
                }
            }

            
        }
    }
}
