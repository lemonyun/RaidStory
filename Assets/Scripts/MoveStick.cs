using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveStick : Stick
{

    public Transform player;
    public Rigidbody playerRig;


    private bool moveFlag;
    private float maxSpeed;
    private float timeZeroToMax;
    private float timeMaxToZero;

    ////// Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        moveFlag = false;
        maxSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveFlag)
        {
            player.transform.Translate(Vector3.forward * Time.deltaTime * 2f);
        } 
        //  player.transform.Translate(Vector3.forward * Time.deltaTime * 5f);

    }


    public override void Drag(BaseEventData _Data)
    {
        moveFlag = true;
        base.Drag(_Data);
        player.eulerAngles = new Vector3(0, Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg, 0);
    }

    public override void DragEnd()
    {
        base.DragEnd();
        moveFlag = false;
        playerRig.velocity = Vector3.zero;
    }

}
