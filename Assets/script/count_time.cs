using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count_time : MonoBehaviour
{
    // Start is called before the first frame update
    public Text time;
    int preTime = 0;
    void Start()
    {   
        time.text = "00:00";
        preTime = (int)Time.realtimeSinceStartup;

    }
    void update_time_play()
    {
        int tmp = (int)Time.realtimeSinceStartup - preTime;
        int h = tmp / 60;
        int s = tmp % 60;
        string sh = h.ToString();
        string ss = s.ToString();
        while (sh.Length < 2) sh = '0' + sh;
        while (ss.Length < 2) ss = '0' + ss;
        time.text = sh + ':' + ss;
    }
    // Update is called once per frame
    void Update()
    {
        update_time_play();
     
    }
}
