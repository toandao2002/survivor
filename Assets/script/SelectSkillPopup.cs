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
       
         
    }

    private void OnEnable()
    {   
        for (int i = 0; i < 3; i++)
        {
            int ran = Random.Range(1, data.skills.Count);
            skills[i].enum_bullet = data.skills[ran].enum_bullet;
            skills[i].image.sprite = data.skills[ran].sprite;
            skills[i].image.SetNativeSize();
            skills[i].name.text = (data.skills[ran].enum_bullet.ToString());
            skills[i].name.transform.GetChild(0).GetComponent<Text>().text = (data.skills[ran].enum_bullet.ToString());
            skills[i].level = data.skills[ran].level;
            skills[i].Describe.text = data.skills[ran].Describe;
        }
        Time.timeScale = 0; // pause game 
 
    }
    private void OnDisable()
    {


        Time.timeScale = 1; //continue game

    }
    private void Update()
    {
         
    }
}
