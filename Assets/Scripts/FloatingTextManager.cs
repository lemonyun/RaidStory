using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[Serializable]
public class FloatingTextManager : MonoBehaviour
{

    public int [] ar;
    public GameObject[] attackDigitPrefabs;
    public GameObject[] hitDigitPrefabs;
    public static FloatingTextManager instance;

    string type;

    public float floatingTime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FloatingText(GameObject obj, int damage, string type)
    {
        
        Vector3 startFloatingPos = new Vector3( obj.transform.position.x, obj.transform.position.y + 2.0f, obj.transform.position.z);
        
        
        float y_offset = 0;

        List<int> li = new List<int>();
        int count = 0;
        while(damage > 0)
        {
            li.Add(damage % 10);
            damage /= 10;
            count++;
        }
        if (PlayerController.instance.is_text_floating)
        {
            y_offset += PlayerController.instance.float_text_count * 0.5f;
        }

        PlayerController.instance.is_text_floating = true;
        PlayerController.instance.float_text_count++;

        int sort = 0;
        switch (type)
        {
            case "attack":
                sort = 0;
                break;
            case "hit":
                sort = 1;
                break;
        }

        GameObject textBox = Instantiate(Resources.Load("damageText")) as GameObject;
        textBox.transform.Translate(new Vector3(0, y_offset, 0));
        for (int i = 0; i < li.Count; i++)
        {
            
            GameObject child;
            if (sort == 0)
            {
                child = Instantiate(attackDigitPrefabs[li[i]], new Vector3(i * 0.35f, 0, 0), Quaternion.Euler(new Vector3(-20, 180, 0)));
            }
            else
            {
                child = Instantiate(hitDigitPrefabs[li[i]], new Vector3(i * 0.35f, 0, 0), Quaternion.Euler(new Vector3(-20, 180, 0)));
            }
            //child.translate()
            child.transform.parent = textBox.transform;
        }
        timer = 0.0f;

        textBox.transform.position = startFloatingPos;
        textBox.transform.Translate(-1.0f *(li.Count * 0.35f - 0.05f) / 2.0f, 0, 0); // 텍스트 위치 수정

       
        while (timer < floatingTime)
        {
            timer += Time.deltaTime;
            textBox.transform.Translate(0, 0.12f, 0.1f);
            
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(textBox);
        PlayerController.instance.float_text_count--;
        if (PlayerController.instance.float_text_count == 0)
        {
            PlayerController.instance.is_text_floating = false;
        }
    } 
}
