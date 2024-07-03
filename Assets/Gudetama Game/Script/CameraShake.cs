using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //카메라 흔들기
    public float ShakeAmount; //카메라가 흔들리는 총량(힘)을 설정 숫자가 높을수록 카메라가 쎄게 흔들린다.
    float ShakeTime; //카메라가 흔들리는 시간을 설정할 수 있다.
    Vector3 initialPosition; //카메라가 흔들리는 위치(진원)이다.


    // 카메라의 흔드는 시간을 설정한다.
    public void VibrateForTime(float time)
    {
        ShakeTime = time;

    }

    //게임이 시작하면 카메라가 흔들릴 위치를 잡아준다.
    void Start()
    {
        initialPosition = new Vector3(0f,0f,-10f);
    }

    //카메라의 움직임이 랜덤으로 카메라의 움직임 총량(힘)만큼 카메라의 위치에서 흔들리게 된다.
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
