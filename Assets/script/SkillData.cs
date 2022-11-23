using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum type_skill
{
    add , inc_dame, inc_speed_bullet ,
}
[System.Serializable]
public class Skill
{
    public type_skill type;
    public int id;
    public BulletName enum_bullet;
    public Sprite sprite;
    public string  Describe;
    public int level = 1;
    public bool is_use = false;
}


[CreateAssetMenu(fileName = "skill_data", menuName = "data/skill_data")]
public class SkillData : ScriptableObject
{   
     
    public List<List<Skill>> merge_skill = new List<List<Skill>>();
    
    public List<Skill> skills;
    public void merge()
    {
         
        List<Skill> tmp=  new List<Skill>();
        for (int i = 0; i < skills.Count;i ++)
        {
            if (i % 5 == 0&& i >0)
            {

                merge_skill.Add(tmp);
                tmp = new List<Skill>();
            }
            skills[i].is_use = false;
            tmp.Add(skills[i]);
        }
        merge_skill.Add(tmp);
        merge_skill[0][0].is_use = true;// kunai defaul start game ;
    }
}
