using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_rocket :  ShootBullet
{
    zombies zombie;
    public float speed;
    int dame = 20;
    
    public long timeInitBullet = 2;
    float preTime = 0;
    Vector3 dir;
    private void Awake()
    {

    }
    private void Start()
    {
        Vector3 randomPos = Random.insideUnitSphere * 50f;
        dir = character.Instance.get_position() + randomPos;
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
         
       
        {

            // quay doi tuong theo huong
         
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, (angle - 90));
            //  di chuyem bullet 
            transform.position = Vector3.MoveTowards(transform.position,dir , speed);
            
        }

         
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Destroy(this.gameObject);
        }
    }

    public override int GetDame()
    {
        return dame;
    }

    public override void SetDame(int value)
    {
        dame = value;
    }

    public override void shoot()
    {

        if (Time.time - preTime > timeInitBullet)
        {

            zombie = FindObjectOfType<zombies>();
            if (zombie != null)
            {

                Bullet_rocket tmp = Instantiate(this, character.Instance.get_position(), Quaternion.identity);
                tmp.is_sample = false;
                tmp.gameObject.SetActive(true);
                preTime = Time.time;

            }

        }
    }
}
