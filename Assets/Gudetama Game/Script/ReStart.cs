using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(restart());
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(18.0f);
        SceneManager.LoadScene("MainMenu");
    }
}
