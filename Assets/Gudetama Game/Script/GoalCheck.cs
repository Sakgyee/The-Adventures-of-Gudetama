using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    //public GameObject Kuromi;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WindController.instance.windForce = 20000f;
            BGM.instance.i += 1;
            MugunghwaFlower.instance.kuromidie();
        }
      
    }
}
