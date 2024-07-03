using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public Transform startPoint;        // ���� ����
    public Transform endPoint;          // �� ����
    public float lineDuration = 2.0f;    // ���� ���� �ð�

    public static Line instance; //���� �����
    private LineRenderer lineRenderer;
    void Awake()
    {
        Line.instance = this; //���� �ʱ�ȭ��

    }
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        DrawStraightLine();
    }

    public void DrawStraightLine()
    {
        //lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);

        // ���� ���� �ð� �Ŀ� ������ ��Ȱ��ȭ�մϴ�.
        //StartCoroutine(DisableLineAfterDelay());
    }

    private System.Collections.IEnumerator DisableLineAfterDelay()
    {
        yield return new WaitForSeconds(lineDuration);
        lineRenderer.positionCount = 0; // ������ ��Ȱ��ȭ�մϴ�.
    }
}