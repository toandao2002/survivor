using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillName
{
    a,
    b
}
[System.Serializable]
public class Skill
{
    public BulletName enum_bullet;
    public Sprite sprite;
    public string  Describe;
    public int level = 1;
    
}


[CreateAssetMenu(fileName = "skill_data", menuName = "data/skill_data")]
public class SkillData : ScriptableObject
{
    public List<Skill> skills;
    
     
}
