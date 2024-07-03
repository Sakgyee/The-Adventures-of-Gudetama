using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fall : MonoBehaviour
{
    public string ReStartMapName; //떨어졌을 때 다시 시작할 맵

    CameraShake Camera;

    private void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Camera.VibrateForTime(0.05f);
            StartCoroutine(Re());           
        }
    }

    IEnumerator Re()
    {
        yield return new WaitForSeconds(0.06f);
        SceneManager.LoadScene(ReStartMapName);
    }
}
