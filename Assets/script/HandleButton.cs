using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleButton : MonoBehaviour
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
    
    public void OnButtonPress()
    {   

        character.Instance.AddNewBullet(nameBullet.text);
    }

}
