using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TextSize : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // ���콺 Ŀ���� ����� ���� ���� �ʾ��� �� �̺�Ʈ
{
    public Text text;
    private int originalFontSize = 50; //�ؽ�Ʈ ���� ũ��
    public int hoverFontSize = 70; // �ؽ�Ʈ�� Ŀ���� ����� ���� ũ��
    public Button loadButton;

    void Start()
    {
        text = GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int currentSceneIndex = PlayerPrefs.GetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        if (currentSceneIndex != 0 && loadButton)
        {
            //���콺 Ŀ���� �ؽ�Ʈ�� ����� ��
            text.fontSize = hoverFontSize;
        }
        if(!loadButton)
        {
            //���콺 Ŀ���� �ؽ�Ʈ�� ����� ��
            text.fontSize = hoverFontSize;
        }  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //���콺 Ŀ���� �ؽ�Ʈ�� ����� ��
        text.fontSize = originalFontSize;
    }
}