using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackStick : Stick
{
    
    private bool attackFlag;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        attackFlag = false;
        PlayerUI.instance.AimLine1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (attackFlag)
        {
            if (PlayerUI.instance.AimLine1.activeSelf == false)
            {
                PlayerUI.instance.AimLine1.SetActive(true);
            }
        }
        else
        {
            PlayerUI.instance.AimLine1.SetActive(false);
        }

    }
    public override void Drag(BaseEventData _Data)
    {
        
        attackFlag = true;
        base.Drag(_Data);
        PlayerUI.instance.AimLine1.transform.localEulerAngles = new Vector3(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
    }

    public override void DragEnd()
    {
        float rotVal = PlayerUI.instance.AimLine1.transform.localEulerAngles.z;
        PlayerUI.instance.AimLine1.SetActive(false);
        base.DragEnd();
        attackFlag = false;
        PlayerController.instance.CastSkill(1, rotVal);
    }

    

}
