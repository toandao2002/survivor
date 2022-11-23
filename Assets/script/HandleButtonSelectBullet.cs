using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleButtonSelectBullet : MonoBehaviour
{ 
   
    public Text nameBullet;
    public int order_button;
    SelectSkillPopup select;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public Sprite  FindBulletInSelectSkill()
    {
         
        return select.skills[order_button].image.sprite;
        
    }
    void handle_type_skill()
    {
        if (select.skills[order_button].type == type_skill.add)
        {
            character.Instance.AddNewBullet(select.skills[order_button].enum_bullet);
        }
        else if (select.skills[order_button].type == type_skill.inc_dame)
        {
            character.Instance.IncreaseDame(select.skills[order_button].enum_bullet);
        }
        else if (select.skills[order_button].type == type_skill.inc_dame)
        {
            character.Instance.IncreaseSpeedBullet(select.skills[order_button].enum_bullet);
        }
        select.data.merge_skill[(int)select.skills[order_button].id / 5][select.skills[order_button].id % 5].is_use = true;
    }
    public void OnButtonPress()
    {
        select = transform.parent.parent.parent.GetComponent<SelectSkillPopup>();
        if (transform.parent.CompareTag("Item1")) order_button = 0;
        else if (transform.parent.CompareTag("Item2")) order_button = 1;
        else   order_button =2;
        handle_type_skill();

        if (!character.Instance.Item.Contains(FindBulletInSelectSkill()))
            character.Instance.Item.Add(FindBulletInSelectSkill());
        transform.parent.parent.parent.parent.gameObject.SetActive(false);
       
        // transform.parent.parent.parent.GetComponent<SelectSkillPopup>().enabled = false;

    }

}
