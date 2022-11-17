using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class frame_skill
{
    public BulletName enum_bullet;
    public Text name;
    public Image image;
    
    public Text Describe;
    public int level ;
}

public class SelectSkillPopup : MonoBehaviour
{
    public SkillData data;
   
    public List<frame_skill> skills;

    private void Awake()
    {
        for(int i = 0; i < data.skills.Count; i++)
        {
            skills[i].enum_bullet = data.skills[i].enum_bullet;
            skills[i].image.sprite = data.skills[i].sprite;
            skills[i].image.SetNativeSize();
            skills[i].name.text = ( data.skills[i].enum_bullet.ToString()) ;
            skills[i].level = data.skills[i].level;
            skills[i].Describe.text = data.skills[i].Describe; 
        }
         
    }
}
