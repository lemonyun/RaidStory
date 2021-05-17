using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonStat : MonoBehaviour
{

    public int hp;
    public int currentHP;
    public int mp;
    public int currentMP;

    public int ad;
    public int ap;

    public int magicalResistance;
    public int armor;

    void Start()
    {
        
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

    public int CalDam(int damage, string property)
    {
        switch (property)
        {
            case "magical":
                damage = (int) (damage * (100 / (float)(100 + magicalResistance)));
                break;
            case "physical":
                damage = (int) (damage * (100 / (float)(100 + armor)));
                break;
            case "fixed":
                damage = damage;
                break;
            
        }
        
        return damage;
    }

    public void Die()
    {
        Destroy(this.gameObject);

    }
}
