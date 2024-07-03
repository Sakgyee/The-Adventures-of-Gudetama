using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{

    public GameObject Player;
    public GameObject startPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (Player != null && startPoint != null)
        {
            Player.transform.position = startPoint.transform.position;
            startPoint.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}