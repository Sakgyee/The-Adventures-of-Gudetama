using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour
{
    public GameObject object_to_move;

    // Start is called before the first frame update
    void Start()
    {
        // ȭ�� ������ ���� ���ϱ� 
        float screenHeightHalf = Camera.main.orthographicSize;
        // ȭ�� ������ ���� ���ϱ� 
        float screenWidthHalf = screenHeightHalf * Camera.main.aspect;
        // ������Ʈ �̵� 
        GameObject obj = object_to_move;
        Vector3 position = obj.transform.localPosition;
        position.x = 0;
        position.y = screenHeightHalf;
        obj.transform.localPosition = position;

        /*
          ȭ�� ���� = 2 * Camera.main.orthographicSize 
          ȭ�� ���� = 2 * (ȭ�� ���� * Camera.main.aspect) 
          Left,Top ��ǥ = -ȭ�� ����/2, ȭ�� ����/2 
          Left,Bottom ��ǥ = -ȭ�� ����/2, -ȭ�� ����/2 
          Right,Top ��ǥ = ȭ�� ����/2, ȭ�� ����/2 
          Right,Bottom ��ǥ = ȭ�� ����/2, -ȭ�� ����/2 
         */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
