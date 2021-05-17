using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CommonStat
{
    public static PlayerStat instance;

    public int character_Lv;
    public int[] needExp;
    public int currentExp;

   
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    
}
