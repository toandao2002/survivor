using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombies : ZombieCommon
{
    
   
   
    
    // Start is called before the first frame update
    
    
    
    
    

     
    

    // Update is called once per frame
    void Update()
    {
        if (character.Instance.blood <= 0) Time.timeScale = 0f;
        if (isCollide == false)
        {
            movetoCharacter();
            Run();
        }

        else
        {
            Attack();
        }
        if (blood <= 0)
        {

            Instantiate(EXP, transform.position, Quaternion.identity);

            int tmp = Int32.Parse(UI.Instance.amount_zombie_die.text);
            tmp++;
            UI.Instance.amount_zombie_die.text = tmp.ToString();


            manage_zombie.Instace.zombies.Remove(this.gameObject);
            Destroy(this.gameObject);

        }


    }
     
     
    
    
   
    

    
}
