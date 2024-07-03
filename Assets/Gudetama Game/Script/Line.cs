using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public Transform startPoint;        // 시작 지점
    public Transform endPoint;          // 끝 지점
    public float lineDuration = 2.0f;    // 라인 지속 시간

    public static Line instance; //변수 선언부
    private LineRenderer lineRenderer;
    void Awake()
    {
        Line.instance = this; //변수 초기화부

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

        // 라인 지속 시간 후에 라인을 비활성화합니다.
        //StartCoroutine(DisableLineAfterDelay());
    }

    private System.Collections.IEnumerator DisableLineAfterDelay()
    {
        yield return new WaitForSeconds(lineDuration);
        lineRenderer.positionCount = 0; // 라인을 비활성화합니다.
    }
}