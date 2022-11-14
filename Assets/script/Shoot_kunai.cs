using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_kunai : MonoBehaviour, ShootBullet
{
    zombies zombie;
    public float speed;
    int dame =20;
     


    private void Start()
    {
        zombie = FindObjectOfType<zombies>();
    }
     

    
    
    // Update is called once per frame
    void Update()
    {   
        if (zombie != null)
        {   

            // quay doi tuong theo huong
            Vector3 dir = zombie.transform.position - transform.position;
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, (  angle - 90 ) );
            //  di chuyem bullet 
            transform.position = Vector3.MoveTowards(transform.position, zombie.transform.position, speed);
        }
            
        else
        {
            zombie = FindObjectOfType<zombies>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if  (collision.gameObject.tag == "Zombie"){
            Destroy(this.gameObject);
       }
    }

    public int GetDame()
    {
        return dame;
    }

    public void SetDame(int value)
    {
        dame = value;
    }

    public void shoot(zombies zombies, float speed, float dame)
    {
         
    }
}
