using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotate : MonoBehaviour
{
    public Transform center;    // ��� �߽���
    public float radius = 2.0f; // ������
    public float speed = 2.0f;  // �ӵ�

    private float angle = 0;

    // Offset angle for each circle
    public float angleOffset = 0.0f;

    void Start()
    {
        // Add the angle offset to the initial angle
        angle += angleOffset;
    }
    void Update()
    {
        angle += speed * Time.deltaTime;
        transform.position = center.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
    }
}
