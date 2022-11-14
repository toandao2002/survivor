using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text time;
    int h, s;
    float time_start;
    // Start is called before the first frame update
    void Start()
    {
        time_start = Time.realtimeSinceStartup;
    }
    void update_time_play()
    {
        float tmp = Time.realtimeSinceStartup - time_start;
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
