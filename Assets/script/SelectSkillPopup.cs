using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class frame_skill
{
    public BulletName enum_bullet;
    public Text name;
    public type_skill type;
    public Image image;
    public int id; 
    public Text Describe;
    public int level ;
    
     
}

public class SelectSkillPopup : MonoBehaviour
{
    public SkillData data;
    public int speed_change_color =5;
    public List<frame_skill> skills;
    [SerializeField]
    public List<GameObject> levels;
    private void Awake()
    {
        data.merge();
    }
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        
        List<int> except_num = new List<int>();
        int ok = 0;
        for (int i = 0; i < 3; i++)
        {

            int ran;
            while (true)
            {   
                ran = Random.Range(0, data.merge_skill.Count);

                ok = 1;
                foreach (int num in except_num)
                {
                    if (num == ran)
                    {
                        
                        ok = 0;
                        break;
                    }
                }
                if (ok == 1 || except_num.Count >= data.merge_skill.Count)
                {
                    
                    except_num.Add(ran);
                    break;
                }
            }
            ok = 0;
            for (int j = 0; j < data.merge_skill[0].Count; j ++)
            {

                if (data.merge_skill[ran][j].is_use == false)
                {
                    ok = 1;
                    //data.merge_skill[ran][j].is_use = true;
                    ran = ran * 5 + j;
                    break;
                }
            }
            if (ok == 0)
            {
               
                ran = ran * 5 + 4;
            }
            
            skills[i].id =ran;
            skills[i].type = data.skills[ran].type;
            skills[i].enum_bullet = data.skills[ran].enum_bullet;
            skills[i].image.sprite = data.skills[ran].sprite;
            skills[i].image.SetNativeSize();
            skills[i].name.text = (data.skills[ran].enum_bullet.ToString());
            skills[i].name.transform.GetChild(0).GetComponent<Text>().text = (data.skills[ran].enum_bullet.ToString());
            skills[i].level = data.skills[ran].level;
            skills[i].Describe.text = data.skills[ran].Describe;
            if (ok == 0)
            {
                skills[i].level = 6;

            }
        }
       
        Time.timeScale = 0; // pause game 
 
    }
    private void OnDisable()
    {


        Time.timeScale = 1; //continue game

    }
    private void Update()
    {
        int j = 0; 

        foreach (GameObject lev in levels)
        {   
            for (int i = 0; i < skills[j].level-1; i++)
            {   
                lev.transform.GetChild(i).GetComponent<Image>().color = new Color32((byte)speed_change_color, (byte)speed_change_color, (byte)speed_change_color, 255);
            }
            for (int i = skills[j].level-1; i < 5; i++)
            {
                lev.transform.GetChild(i).GetComponent<Image>().color = new Color32(128, 64, 64, 255);
            }
            speed_change_color += 5;
            j++;
        }
    }
}
