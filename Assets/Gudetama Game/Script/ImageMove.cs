using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour
{
    public GameObject object_to_move;

    // Start is called before the first frame update
    void Start()
    {
        // 화면 높이의 절반 구하기 
        float screenHeightHalf = Camera.main.orthographicSize;
        // 화면 넓이의 절반 구하기 
        float screenWidthHalf = screenHeightHalf * Camera.main.aspect;
        // 오브젝트 이동 
        GameObject obj = object_to_move;
        Vector3 position = obj.transform.localPosition;
        position.x = 0;
        position.y = screenHeightHalf;
        obj.transform.localPosition = position;

        /*
          화면 높이 = 2 * Camera.main.orthographicSize 
          화면 넓이 = 2 * (화면 높이 * Camera.main.aspect) 
          Left,Top 좌표 = -화면 넓이/2, 화면 높이/2 
          Left,Bottom 좌표 = -화면 넓이/2, -화면 높이/2 
          Right,Top 좌표 = 화면 넓이/2, 화면 높이/2 
          Right,Bottom 좌표 = 화면 넓이/2, -화면 높이/2 
         */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
