using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //ī�޶� ����
    public float ShakeAmount; //ī�޶� ��鸮�� �ѷ�(��)�� ���� ���ڰ� �������� ī�޶� ��� ��鸰��.
    float ShakeTime; //ī�޶� ��鸮�� �ð��� ������ �� �ִ�.
    Vector3 initialPosition; //ī�޶� ��鸮�� ��ġ(����)�̴�.


    // ī�޶��� ���� �ð��� �����Ѵ�.
    public void VibrateForTime(float time)
    {
        ShakeTime = time;

    }

    //������ �����ϸ� ī�޶� ��鸱 ��ġ�� ����ش�.
    void Start()
    {
        initialPosition = new Vector3(0f,0f,-10f);
    }

    //ī�޶��� �������� �������� ī�޶��� ������ �ѷ�(��)��ŭ ī�޶��� ��ġ���� ��鸮�� �ȴ�.
    void Update()
    {
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
            transform.position = initialPosition;
        }
    }

}
