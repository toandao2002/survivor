using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkillPopup : MonoBehaviour
{
    public SkillData data;
    public List<Image> img_skills;

    private void Awake()
    {
        for(int i = 0; i < data.skills.Count; i++)
        {
            img_skills[i].sprite = data.skills[i].img;
            img_skills[i].SetNativeSize();
        }
    }
}
