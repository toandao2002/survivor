using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_kunai : ShootBullet
{
    zombies zombie;
    public float speed;
    int dame =20;
   
    public long timeInitBullet = 2;
    float preTime = 0;
    private void Awake()
    {
         
    }
    private void Start()
    {
         
    }
     

    
    
    // Update is called once per frame
    void Update()
    {


        if (is_sample)
        {
            dame = 0;
            gameObject.SetActive(false);
            return;
            
        }
        gameObject.SetActive(true);
        if (zombie != null)
        {
            
            // quay doi tuong theo huong
            Vector3 dir = zombie.transform.position - character.Instance.get_position();
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

    public override int GetDame()
    {
        return dame;
    }

    public  override void SetDame(int value)
    {
        dame = value;
    }

    public override void shoot( )
    {
        
        if (Time.time - preTime > timeInitBullet) 
        {
             
            zombie = FindObjectOfType<zombies>();
            if (zombie != null)
            {

                Shoot_kunai tmp = Instantiate(this, character.Instance.get_position(), Quaternion.identity);
                tmp.is_sample = false ;
                tmp.gameObject.SetActive(true);
                preTime = Time.time;

            }
           
        }
    }
}
