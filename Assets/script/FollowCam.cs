using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public Transform target;    // 추적할 타겟 오브젝트의 Transform
    public float dist = 10.0f;  // 카메라와의 일정 거리
    public float height = 5.0f; // 카메라의 높이 설정
    public float smoothRotate = 5.0f;   // 부드러운 회전을 위한 변수
	public int escount = 0;

    private Transform tr; // 카메라 자신의 Transform 변수
    private float wheel; //카메자 줌인, 줌아웃을 위한 변수

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Exectue When Update Func is ended.
    void LateUpdate()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (escount == 0) {
				escount = 1;
			}
			else {
				escount = 0;
			}
		}
		if (escount == 0) {

            //플레이어와 화면사이의 벡터 정보
            Vector3 PositionInfo = tr.position - target.position;
            // 화면 확대가 너무 급격히 일어나지 않도록 정규화
            PositionInfo = Vector3.Normalize(PositionInfo);

            // 부드러운 회전을 위한 Mathf.LerpAngle
            float currYAngle = Mathf.LerpAngle (tr.eulerAngles.y, target.eulerAngles.y, smoothRotate * Time.deltaTime);

			// 오일러 타입을 쿼터니언으로 바꾸기
			Quaternion rot = Quaternion.Euler (0, currYAngle, 0);

            //휠로 화면을 줌인 줌 아웃
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && wheel < 2)
                wheel++;
            if (Input.GetAxis("Mouse ScrollWheel") < 0f && wheel > -8)
                wheel--;

			// 카메라 위치를 타겟 회전각도만큼 회전 후 dist만 큼 띄우고, 높이를 올리기 그리고 휠로 줌인 줌 아웃
			tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height) - (PositionInfo * wheel * 2f);
  

            // 타겟을 바라보게 하기
            tr.LookAt (target);

        }
    }
}
