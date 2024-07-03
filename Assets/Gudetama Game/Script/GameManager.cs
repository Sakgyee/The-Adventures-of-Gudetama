using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //���� �����
    public GameObject SP;
    public ParticleSystem particleObject; //��ƼŬ�ý���
    public int BDP = 0;
    public GameObject Option;
    public GameObject Setting;
    public GameObject Player;
    public GameObject boss;    
    public GameObject bullets;
    public GameObject gameover;
    public GameObject onejump;
    public GameObject bf;
    public GameObject bf1;
    public GameObject bf2;
    public GameObject bf3;
    public GameObject bf4;
    public string ReStartMapName;
    public Button loadButton;
    public Color disabledTextColor = Color.gray; // ��Ȱ��ȭ ��ư�� �帴�ϰ� ����� ����
    public GameObject Portal;
    AudioSource audioSource;
    public AudioSource saveSound;
    public AudioSource gameOverSound;
    public AudioSource bossdieSound;
    /*
    public GameObject block;
    List<GameObject> jumprelist = new List<GameObject>();

    void jumpRe()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject _obj = Instantiate(block) as GameObject;
            jumprelist.Add(_obj);
        }
    }
    */
    void Awake()
    {
        GameManager.instance = this; //���� �ʱ�ȭ��
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        BDP = 0;
        if(ReStartMapName == "BossStage")
        {

        }
        else
        {
            GameLoad();
            SP.SetActive(true);
        }
        
        if (gameover != null)
        {
            gameover.gameObject.SetActive(false);

        }
        //Instantiate(Player);

        //jumpRe();
    }

    void Update()
    {    
                
        if (SceneManager.GetActiveScene().name == "BossStage")
        {
            if (Boss.instance.bossnowhp <= 0 && BDP < 1)
            {
                audioSource = bossdieSound;
                audioSource.Play();
                particleObject.Play();
                BDP += 1;
                Portal.SetActive(true);
            }
            if (Boss.instance.bossnowhp > 0 && !boss.activeSelf)
            {
                boss.gameObject.SetActive(true);
            }

            if (!bf.activeSelf)
            {
                bf1.transform.position = new Vector2(4f, 9f);
                bf2.transform.position = new Vector2(8f, 9f);
                bf3.transform.position = new Vector2(-4f, 9f);
                bf4.transform.position = new Vector2(-8f, 9f);
                bf1.gameObject.SetActive(false);
                bf2.gameObject.SetActive(false);
                bf3.gameObject.SetActive(false);
                bf4.gameObject.SetActive(false);
            }
            else if (bf.activeSelf)
            {
                bf1.gameObject.SetActive(true);
                bf2.gameObject.SetActive(true);
                bf3.gameObject.SetActive(true);
                bf4.gameObject.SetActive(true);
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if(Option.activeSelf)
            {
                Option.SetActive(false);
            }
            else
            {
                Option.SetActive(true);
            }
            if(Setting.activeSelf)
            {
                Setting.SetActive(false);
            }
           
            
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            GameLoad();
            
            if (ReStartMapName == "Main 1")
            {
                SceneManager.LoadScene(ReStartMapName);
            }
            else
            {
                loadscene();
            }
            if(gameover != null)
            {
                gameover.gameObject.SetActive(false);
               
            }
            
        }

        int currentSceneIndex = PlayerPrefs.GetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        // ���� �ε������� 0�̸� ��ư�� ��Ȱ��ȭ ��Ų��
        if (currentSceneIndex == 0)
        {
            bool isButtonInteractable = (SceneManager.GetActiveScene().buildIndex != 0);

            // ��ư ��ȣ �ۿ� ���� �Ӽ� ����
            loadButton.interactable = isButtonInteractable;

            // ��ȣ�ۿ뼺�� ���� �ؽ�Ʈ ���� ����
            Text buttonText = loadButton.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.color = isButtonInteractable ? Color.white : disabledTextColor;
            }
        }

    }

    public void GameSave()
    {
        audioSource = saveSound;
        audioSource.Play();
        PlayerPrefs.SetFloat("PlayerX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", Player.transform.position.y);
        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex); //�÷��̾� ��ġ �� ����      
        PlayerPrefs.Save();     
    }
    public void GameLoad()
    {
        if (gameover != null)
        {
            gameover.gameObject.SetActive(false);

        }
        if (!PlayerPrefs.HasKey("PlayerX"))
        {
            return;
        }

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
       

        Player.transform.position = new Vector3(x, y, 0);

        Bullets.instance.ResetBullet();
        /*if(bullets != null)
        {
            Destroy(bullets);
        }   
        */
        Player.gameObject.SetActive(true);

        if(onejump != null)
        {
            onejump.gameObject.SetActive(true);
        }
        
    }
    public void GameOver()
    {
        StartCoroutine(gameoverso());
    }
    IEnumerator gameoverso()
    {
        yield return new WaitForSeconds(0.5f);
        audioSource = gameOverSound;
        audioSource.Play();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void loadscene()
    {
        int currentSceneIndex = PlayerPrefs.GetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);  //�÷��̾� ��ġ �� �ε�
        SceneManager.LoadScene(currentSceneIndex);
    }
}
