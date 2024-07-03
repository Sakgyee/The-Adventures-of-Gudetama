using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeEffect : MonoBehaviour
{
    private Image image; //���̵忡 �ʿ��� ���� ���� �̹���
    
    public Text Title;
    public Text Op;
    public Text St;
    public Text End;
    public Text Load;

    public GameObject start;
    public GameObject load;
    private void Awake()
    {
        image = GetComponent<Image>(); //�̹����� ������
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
        //image color �Ӽ�(������Ƽ)�� a������ ���� set�� �Ұ����ؼ� ������ ����
        Color color = image.color;
        
        //���� ��(a)�� 0���� ũ�� ���� �� ���� ���̵� �ƿ�
        /*
        if(color.a > 0)
        {
            color.a -= Time.deltaTime;
        }
        */
        //���� ��(a)�� 0���� ũ�� ���� �� ���� ���̵� ��
        if (color.a < 1)
        {
            color.a += Time.deltaTime;
        }
        //�ٲ� ���� ������ image.color�� ����
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
        int currentSceneIndex = PlayerPrefs.GetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);  //�÷��̾� ��ġ �� �ε�
        SceneManager.LoadScene(currentSceneIndex);       
    }
}
