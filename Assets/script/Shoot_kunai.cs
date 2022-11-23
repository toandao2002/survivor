using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_kunai : ShootBullet
{
    ZombieCommon zombie;
    public float speed;
    public static int dame = 10;
    Vector3 des ;
    bool flag_shoot = false;
    public long timeInitBullet = 2;
   
    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        zombie = null;
        flag_shoot = false;
    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        move();
        if (OutOfSreen())
        {
            this.gameObject.SetActive(false);
        }

            
       
    }
    void move()
    {
        

        transform.Translate(des * 10 * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if  (collision.gameObject.tag == "Zombie"){
            this.gameObject.SetActive(false);
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

        GameObject zombieObject = FindZombieNearest();
        if (zombieObject != null)
            zombie = zombieObject.GetComponent<ZombieCommon>();
       // zombie = FindObjectOfType<zombies>();
        if (zombie != null && flag_shoot == false)
        {
            flag_shoot = true;
            // quay doi tuong theo huong
            Vector3 dir = zombie.transform.position - character.Instance.get_position();

            dir.Normalize();
            des = dir;
            float angle = Vector2.Angle(dir, Vector2.up);
            if (dir.x > 0) angle *= -1;
            transform.GetChild(0).localRotation = Quaternion.Euler(0, 0, (angle - 45));
            
        }
        else if (flag_shoot == false)
        {
            flag_shoot = true;
            Vector3 randompos = Random.insideUnitSphere.normalized;
            randompos.z = 0;
            
            des = character.Instance.get_position() + randompos;
            Vector3 dir = des;

            dir.Normalize();
            des = dir;

            float angle = Vector2.Angle(dir, Vector2.up);
            if (dir.x > 0) angle *= -1;
            transform.GetChild(0).localRotation = Quaternion.Euler(0, 0, (angle - 45));
        }
    }

    public override long  get_init_bullet()
    {
        return timeInitBullet;
    }
}
