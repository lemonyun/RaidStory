using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUI : CharacterUI
{
    public static MonsterUI instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.value = (float)MonsterStat.instance.currentHP / (float)MonsterStat.instance.hp;
        HPBar.transform.position = HeadUpPosition.transform.position;
        MpBar.value = (float)MonsterStat.instance.currentMP / (float)MonsterStat.instance.mp;
        MpBar.transform.position = HeadUpPosition2.transform.position;
            
    }
}
