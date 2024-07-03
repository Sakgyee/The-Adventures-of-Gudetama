using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TextSize : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // 마우스 커서가 닿았을 때와 닿지 않았을 때 이벤트
{
    public Text text;
    private int originalFontSize = 50; //텍스트 원래 크기
    public int hoverFontSize = 70; // 텍스트에 커서가 닿았을 때의 크기
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
            //마우스 커서가 텍스트에 닿았을 때
            text.fontSize = hoverFontSize;
        }
        if(!loadButton)
        {
            //마우스 커서가 텍스트에 닿았을 때
            text.fontSize = hoverFontSize;
        }  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //마우스 커서가 텍스트를 벗어났을 때
        text.fontSize = originalFontSize;
    }
}