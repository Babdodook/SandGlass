using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform playerCharater;   // 추적할 타겟 오브젝트의 Tranform
    public float camDistance = 1.0f;    // 카메라와의 거리 설정
    public float camHeight = 5.0f;       // 카메라 높이 설정
    public float smoothRotate = 5.0f;   // 부드러운 카메라 회전을 위한 변수

    private Transform camTransform;     // 카메라 변환을 위한 Transform 설정

    void Start()
    {
        // 컴포넌트를 이용한 카메라 변환 상태 부여
        camTransform = GetComponent<Transform>();
    }

    void Update()
    {
        // 
        float currYangle = Mathf.LerpAngle(camTransform.eulerAngles.y, playerCharater.eulerAngles.y, smoothRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, currYangle, 0);

        // 카메라 위치를 타겟 회전 각도만큼 변경, camDistance만큼 띄우고, camHeight를 이용해 높이 조절
        camTransform.position = playerCharater.position - (rot * Vector3.forward * camDistance) + (Vector3.up * camHeight);

        // 바라보는 방향 설정
        camTransform.LookAt(playerCharater);
    }
}
