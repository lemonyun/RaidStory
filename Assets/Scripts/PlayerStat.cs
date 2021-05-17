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
    public void Hit(GameObject obj, int damage, string property, string hitoratk)
    {
        int calDam = CalDam(damage, property);
        currentHP -= calDam;
        
        FloatingTextManager.instance.StartCoroutine(FloatingTextManager.instance.FloatingText(obj, calDam, hitoratk));

        if(currentHP < 0){
            Die();
        }
    }
    
    public void Die(){
        base.Die();
        GameObject go = GameObject.Find("HpSlider_p");
        Destroy(go);
        go = GameObject.Find("MpSlider_p");
        Destroy(go);
        
    }
    
}
