using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int x=0, y=0, z=0, k=255;
    // Update is called once per frame
    void Update()
    {
        if ((int)(Time.realtimeSinceStartup * 5) % 3 == 0)
        {
            x += 3;
            y += 5;
            z += 7;
            
            this.GetComponent<Image>().color = new Color32((byte)x, (byte)y, (byte)z, (byte)k);
        }
        
    }
    
}
