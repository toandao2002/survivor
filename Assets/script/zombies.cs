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
    character character;
    private int blood = 20 ;
    private int dame;
     
    private int GetDame()
    {
        return dame;
    }

    private void SetDame(int value)
    {
        dame = value;
    }

    private bool isCollide = false;
    void Start()
    {   
         
        character = FindObjectOfType<character>();
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
           

            Destroy(this.gameObject);
        }
    }
    public void movetoCharacter()
    {
         
        transform.position = Vector3.MoveTowards(transform.position, character.transform.position, step);

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
