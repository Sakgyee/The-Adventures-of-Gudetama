using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextSignal : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Dan;
    public GameObject Jin;

    public void signal()
    {
        StartCoroutine(Textsignal());
    }
    IEnumerator Textsignal()
    {
        Boss.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Dan.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Jin.SetActive(true);
    }

    public void BossStage()
    {
        SceneManager.LoadScene("BossStage");
    }
}
