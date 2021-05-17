using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    public int skillID;
    public string skillName;
    public string skillDescription;
    public int skillCount;
    public Sprite skillIcon;
    public SkillType skillType;

    public enum SkillType
    {
          Aim,
          NoAim,

    }

    public Skill(int _skillID, string _skillName, string _skillDescription, SkillType _skillType, int _skillCount = 1)
    {
        skillID = _skillID;
        skillName = _skillName;
        skillDescription = _skillDescription;
        skillCount = _skillCount;
        skillIcon = Resources.Load("SkillIcon/" + _skillID.ToString(), typeof(Sprite)) as Sprite;   
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
