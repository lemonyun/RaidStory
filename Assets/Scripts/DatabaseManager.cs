using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

    }
    public string[] var_name;
    public float[] var;

    public string[] switch_name;

    public bool[] boss_clear_switches;

    public string[] chr_name;
    public bool[] chr_open_switches;

    public List<Skill> skillList = new List<Skill>();


    // Start is called before the first frame update
    void Start()
    {
        skillList.Add(new Skill(10001, "화염구", "전방에 화염구를 발사합니다", Skill.SkillType.Aim));
    }

  
}
