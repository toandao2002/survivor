using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOrOffSound : MonoBehaviour
{
    int on = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mangerSound()
    {
        if (on == 1)
        {
            on *=-1;
            ManageAudio.Instance.getaudio().Stop();
        }
        else
        {
            on *= -1;
            ManageAudio.Instance.getaudio().Play();
        }
    }
    
}
