using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huanraojupan :   ShootBullet
{
    zombies zombie;
    public float speed, speed_angle;
    public static int dame = 10 ;
    public long  timeInitBullet= 2;
    /*  public bool is_sample = false;*/

    float angle ;
    Vector3 center_circle;
    public override void shoot()
    {
   
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (is_sample)
        {
            dame = 0;
            gameObject.SetActive(false);
            return;

        }*/
 
    
  
          /*  center_circle = character.Instance.get_position();
            transform.position = center_circle + new Vector3 (Mathf.Cos(angle) * radius, Mathf.Sin(angle) *radius  , 0 ) ;
            angle += speed;*/
            transform.RotateAround(transform.position, Vector3.forward , speed_angle * Time.deltaTime);
    }
    public override int GetDame()
    {
        return dame;
    }

    public override void SetDame(int value)
    {
        dame = value;
    }
    public override long get_init_bullet()
    {
        return timeInitBullet;
    }
}
