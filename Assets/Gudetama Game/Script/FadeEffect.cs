using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeEffect : MonoBehaviour
{
    private Image image; //페이드에 필요한 검은 바탕 이미지
    
    public Text Title;
    public Text Op;
    public Text St;
    public Text End;
    public Text Load;

    public GameObject start;
    public GameObject load;
    private void Awake()
    {
        image = GetComponent<Image>(); //이미지를 가져옴
    }

    void Update()
    {

        Color c = Title.color;
        Color co = Op.color;
        Color col = St.color;
        Color colo = End.color;
        Color coloR = Load.color;

        if (c.a > 0)
        {
            c.a -= Time.deltaTime;
        }
        
        Title.color = c;

        if (co.a > 0)
        {
            co.a -= Time.deltaTime;
        }

        Op.color = co;

        if (col.a > 0)
        {
            col.a -= Time.deltaTime;
        }

        St.color = col;

        if (colo.a > 0)
        {
            colo.a -= Time.deltaTime;
        }

        End.color = colo ;

        if (coloR.a > 0)
        {
            coloR.a -= Time.deltaTime;
        }

        Load.color = coloR;

        StartCoroutine(fadein());
        
        if (start.activeSelf)
        {
            StartCoroutine(GameStart());
        }
        if (load.activeSelf)
        {
            StartCoroutine(Gameload());
        }
    }
    IEnumerator fadein()
    {
        yield return new WaitForSeconds(1.0f);
        //image color 속성(프로퍼티)은 a변수만 따로 set이 불가능해서 변수에 저장
        Color color = image.color;
        
        //알파 값(a)이 0보다 크면 알파 값 감소 페이드 아웃
        /*
        if(color.a > 0)
        {
            color.a -= Time.deltaTime;
        }
        */
        //알파 값(a)이 0보다 크면 알파 값 증가 페이드 인
        if (color.a < 1)
        {
            color.a += Time.deltaTime;
        }
        //바뀐 색상 정보를 image.color에 저장
        image.color = color;
    }
    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Tutorial");
    }
    IEnumerator Gameload()
    {
        yield return new WaitForSeconds(3.0f);
        
        loadscene();
    }
    public void loadscene()
    {       
        int currentSceneIndex = PlayerPrefs.GetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);  //플레이어 위치 씬 로드
        SceneManager.LoadScene(currentSceneIndex);       
    }
}
