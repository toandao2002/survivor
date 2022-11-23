using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject setting;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SettingActive()
    {
        setting.SetActive(true);
         
        Time.timeScale = 0f;
    }
    public void GameContinue()
    {
        setting.SetActive(false);
        
        Time.timeScale = 1f;
    }
    
}
