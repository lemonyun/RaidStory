using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public static MonsterController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hit(int damage, string property)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fire")
        {
            FireBall fb = other.gameObject.GetComponent<FireBall>();

            MonsterStat.instance.Hit(this.gameObject, fb.damage, "magical", "attack");
            //Destroy(other.gameObject);
        }
    }
}
