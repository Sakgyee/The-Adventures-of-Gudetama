using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                    SceneManager.LoadScene("Tutorial");            
                break;
            case BTNType.Continue1:

                SceneManager.LoadScene("Dungeon1");
                break;
            case BTNType.Continue2:
                
                SceneManager.LoadScene("Dungeon2");
                break;
            case BTNType.Continue3:
                
                SceneManager.LoadScene("Dungeon3");
                break;
            case BTNType.Option:
                SceneManager.LoadScene("startstroy"); 
                break;
            case BTNType.Sound:

                break;
            case BTNType.Back:
                SceneManager.LoadScene("Main");
                break;
            case BTNType.Next:
                SceneManager.LoadScene("village");
                break;
            case BTNType.Quit:
                    Application.Quit();
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
