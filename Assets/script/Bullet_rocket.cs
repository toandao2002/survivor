using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_rocket : ShootBullet
{
    ZombieCommon zombie;
    public GameObject Explosion;
    public float speed;
    int dame = 20;
    Vector3 des;
    bool flag_shoot = false;
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



        move();
        if (transform.position == des)
        {
            
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            //Destroy(this.gameObject);
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
    void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, des, speed);
    }
    
    public override void shoot()
    {
        // set dir  for bullet 
        GameObject zombieObject = FindZombieNearest();
        if (zombieObject != null)
            zombie = zombieObject.GetComponent<ZombieCommon>();
        // zombie = FindObjectOfType<zombies>();
        if (zombie != null && flag_shoot == false)
        {
            flag_shoot = true;
            des = zombie.transform.position;
            // quay doi tuong theo huong
            Vector3 dir = zombie.transform.position - character.Instance.get_position();
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, (angle - 90));
            //  di chuyem bullet 

        }
        else if (flag_shoot == false)
        {
            flag_shoot = true;
            Vector3 randompos = Random.insideUnitSphere * 5;
            randompos.z = 0;
            des = character.Instance.get_position() + randompos;
            // quay doi tuong theo huong
            Vector3 dir = randompos;
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, (angle - 90));
        }
        des.z = 0;
    }
           
          
}
