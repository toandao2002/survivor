using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{   
    
    public static UI Instance { get; private set; }
    public Text time;
    public Text amount_zombie_die;
    int h, s;
    float time_start;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        time_start = Time.time;
        amount_zombie_die.text = "0";
    }
    public void SetTimeScale(float t)
    {
        Time.timeScale = t;
    }
    void update_time_play()
    {   
        float tmp = Time.time - time_start;
    
        h = (int)tmp / 60;
        s = (int)(tmp) % 60;
        
        string sh = h.ToString()  ;
        while (sh.Length < 2) sh = '0' + sh;
        string ss = s.ToString();
        while (ss.Length < 2) ss = '0' + ss;
        time.text = sh + ':' + ss;

    }
    // Update is called once per frame
    void Update()
    {
        update_time_play();
    }
}
