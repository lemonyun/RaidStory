using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stick : MonoBehaviour
{

    // 공개
    public Transform stick;         // 조이스틱.

    // 비공개
    private Vector3 StickFirstPos;  // 조이스틱의 처음 위치.
    protected Vector3 vec;         // 조이스틱의 벡터(방향)
    private float Radius;           // 조이스틱 배경의 반 지름.

    public virtual void Start()
    {
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.35f;
        StickFirstPos = stick.transform.position;

        // 캔버스 크기에대한 반지름 조절.
        float can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= can;
    }
    
    // 드래그
    public virtual void Drag(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;
        
        // 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래)
        vec = (Pos - StickFirstPos).normalized;

        // 조이스틱의 처음 위치와 현재 내가 터치하고있는 위치의 거리를 구한다.
        float dis = Vector3.Distance(Pos, StickFirstPos);

        // 거리가 반지름보다 작으면 조이스틱을 현재 터치하고 있는곳으로 이동. 
        if (dis < Radius)
            stick.position = StickFirstPos + vec * dis;
        // 거리가 반지름보다 커지면 조이스틱을 반지름의 크기만큼만 이동.
        else
            stick.position = StickFirstPos + vec * Radius;
    }

    // 드래그 끝.
    public virtual void DragEnd()
    {
        stick.position = StickFirstPos; // 스틱을 원래의 위치로.
        vec = Vector3.zero;          // 방향을 0으로.
    }
}