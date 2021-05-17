using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : CommonStat
{
    public static MonsterStat instance;
    // Start is called before the first frame update
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
        GameObject go = GameObject.Find("MpSlider_m");
        Destroy(go);
        Debug.Log(go);
        go = GameObject.Find("HpSlider_m");
        Debug.Log(go);
        Destroy(go);
    }

    
}
