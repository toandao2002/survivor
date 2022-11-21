using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleButtonSelectBullet : MonoBehaviour
{ 
   
    public Text nameBullet;
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
        foreach (Skill fs in transform.parent.parent.parent.GetComponent<SelectSkillPopup>().data.skills )
        {
            if (fs.enum_bullet.ToString() .Equals(nameBullet.text ))
            {
                
                return fs.sprite;
            }
        }
        return null;
    }
    
    public void OnButtonPress()
    {   

        character.Instance.AddNewBullet(nameBullet.text);
        if (!character.Instance.Item.Contains(FindBulletInSelectSkill()))
            character.Instance.Item.Add(FindBulletInSelectSkill());
        transform.parent.parent.parent.parent.gameObject.SetActive(false);
       
        // transform.parent.parent.parent.GetComponent<SelectSkillPopup>().enabled = false;

    }

}
