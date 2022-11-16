using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillName
{
    a,
    b
}
[System.Serializable]
public class Skill
{
    public SkillName name;
    public Sprite img;
}


[CreateAssetMenu(fileName = "skill_data", menuName = "data/skill_data")]
public class SkillData : ScriptableObject
{
    public List<Skill> skills;
}
