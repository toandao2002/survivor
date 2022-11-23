using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_rocket : ShootBullet
{
    ZombieCommon zombie;
    public GameObject Explosion;
    public float speed;
    public static int dame = 15;
    Vector3 des;
    bool flag_shoot = false;
    public long timeInitBullet = 3;
    
    private void Awake()
    {

    }
    private void Start()
    {
        zombie = null;
        flag_shoot = false;
    }
    private void OnEnable()
    {
        zombie = null;
        flag_shoot = false;
    }




    // Update is called once per frame
    void Update()
    {



        move();
        if (transform.position == des)
        {
            
            Instantiate(Explosion, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
             
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

    public override long get_init_bullet()
    {
        return timeInitBullet;
    }
}
