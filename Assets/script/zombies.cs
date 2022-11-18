using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombies : MonoBehaviour
{
    public GameObject EXP;
   
   
    public float step;
    // Start is called before the first frame update
    
    private int blood = 5 ;
    public int dame ;
    
    public  int GetDame()
    {
        return dame;
    }

    public void SetDame(int value)
    {
        dame = value;
    }

    private bool isCollide = false;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      
        if (isCollide== false)
            movetoCharacter();
        if (blood <= 0)
        {
             
            Instantiate(EXP, transform.position, Quaternion.identity  );

            int tmp = Int32.Parse(UI.Instance.amount_zombie_die.text);
            tmp++;
            UI.Instance.amount_zombie_die.text = tmp.ToString();

            foreach (GameObject zombie in manage_zombie.Instace.zombies)
            {

                if (zombie == this.gameObject)
                {
                    manage_zombie.Instace.zombies.Remove(zombie);
                    break;
                }
            }
            Destroy(this.gameObject);
        }
    }
    public void movetoCharacter()
    {
         
        transform.position = Vector3.MoveTowards(transform.position, character.Instance.transform.position, step);

    }
     
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            isCollide = true;
        }
         
        
        if (collision.gameObject.tag == "Bullet" )
        {
            int tmp = collision.gameObject.GetComponent<ShootBullet>().GetDame();
            blood -= tmp;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        {

            isCollide = false;
        }
    }
    private int GetBlood()
    {
        return blood;
    }

    private void SetBlood(int value)
    {
        blood = value;
    }
}
