using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadParticle : MonoBehaviour
{
    public GameObject player;
    public GameObject DP;

    public GameObject boss;
    public GameObject BDP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player != null)
        {          
            DP.transform.position = player.transform.position;
        }
        if (boss != null)
        {
            BDP.transform.position = boss.transform.position;
        }
    }
    
}
