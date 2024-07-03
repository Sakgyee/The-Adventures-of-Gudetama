using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;



    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {         
            if(transferMapName == "Tutorial 1")
            {
                SceneManager.LoadScene("Tutorial 1");
            }
            if (transferMapName == "Tutorial 2")
            {
                SceneManager.LoadScene("Tutorial 2");
            }
            if (transferMapName == "Tutorial 3")
            {
                SceneManager.LoadScene("Tutorial 3");
            }
            if (transferMapName == "Main 1")
            {
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene("Main 1");
            }
            if (transferMapName == "Main 2")
            {
                //PlayerPrefs.DeleteAll();
                SceneManager.LoadScene("Main 2");
            }
            if (transferMapName == "Main 3")
            {
                //PlayerPrefs.DeleteAll();
                SceneManager.LoadScene("Main 3");
            }
            if (transferMapName == "BossCutScene")
            {
                SceneManager.LoadScene("BossCutScene");
            }
            if (transferMapName == "BossStage")
            {
                SceneManager.LoadScene("BossStage");
            }
            if (transferMapName == "Ending")
            {
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene("Ending");
            }
        }


    }

}