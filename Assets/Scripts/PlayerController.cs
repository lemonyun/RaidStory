using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject FireballPrefab;
    public GameObject Player;
    public GameObject ThrowStartPosition;

    public static PlayerController instance;

    private PlayerStat plStat;
    private Rigidbody myRigid;

    public bool is_text_floating = false;
    public int float_text_count;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        plStat = GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    //void Update()
    //{
       
    //}

    public void CastSkill(int num, float rotVal)
    {
        switch (num)
        {
            case 1:
                GameObject instance = Instantiate(FireballPrefab, ThrowStartPosition.transform.position, Quaternion.Euler(new Vector3(0, -rotVal, 0))) as GameObject;
                Player.transform.eulerAngles = new Vector3(0, -rotVal, 0);
                Destroy(instance, 2.0f);
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            MonsterStat monstat = collision.gameObject.GetComponent<MonsterStat>();
            PlayerStat.instance.Hit(this.gameObject, monstat.ad, "physical", "hit");
        }
    }
}
