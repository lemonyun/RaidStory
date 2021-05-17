using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : CharacterUI
{
    public static PlayerUI instance;
    public GameObject AimLine1;
    public GameObject AimStartPosition;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        //AimLine1 = Instantiate(AimLine1, Player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.value = (float)PlayerStat.instance.currentHP / (float)PlayerStat.instance.hp;
        HPBar.transform.position = HeadUpPosition.transform.position;
        MpBar.value = (float)PlayerStat.instance.currentMP / (float)PlayerStat.instance.mp;
        MpBar.transform.position = HeadUpPosition2.transform.position;
        AimLine1.transform.position = AimStartPosition.transform.position;
        //if (AimLine1.activeSelf == true)
        //{
        //    AimLine1.transform.position = Player.transform.position;
        //}
    }
}
