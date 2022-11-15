using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    
    
    public static character Instance { get; private set; }
    public Vector3 get_position()
    {
        return transform.position;
    }
    List<ShootBullet> bullets  ; 
    public Camera main_camera;
    public float speed;
    public Image EXP;

    public List<ShootBullet> bullet_prefabs;
    //public BulletBrick bulletBrick;
    //public manage_haunrs haurs;
    public Joystick joystick;
    
    Animator anim;
    //public Shoot_kunai shoot_kunai;
    const int IDLE = 0;
    const int WALK = 1;
    public long   timeInitBullet , preTime ;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        bullets = new List<ShootBullet>();
        bullet_prefabs[(int) BulletName.kunai].is_sample = true;
    }
    void Start()
    {
        preTime = (long)Time.realtimeSinceStartup;
        anim = GetComponent<Animator>();
        ShootBullet tmp = Instantiate(bullet_prefabs[(int)BulletName.kunai], transform.position, Quaternion.identity);
        bullets.Add(tmp);
        bullet_prefabs[(int)BulletName.brick].is_sample = true;
         
        bullets.Add(Instantiate(bullet_prefabs[(int)BulletName.brick], transform.position, Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(joystick.Horizontal, joystick.Vertical) * speed * Time.deltaTime);
        main_camera.transform.position = transform.position + new Vector3 (0,0,-10);
        foreach (var bullet in bullets)
        {
            bullet.shoot();
       
        }
        if (EXP.fillAmount >= 1)
        {
             
            bullets.Add(Instantiate(bullet_prefabs[(int)BulletName.huanr], transform.position, Quaternion.identity) );
            EXP.fillAmount = 0;
        }

    }
   /* void shoot()
    {
        zombies zombies;
        zombies = FindObjectOfType<zombies>();
        if (zombies != null)
        {
            Instantiate(shoot_kunai, transform.position , Quaternion.identity );
        }
             
    }*/
    public void run()
    {
         
        anim.SetInteger("state", WALK);
    }
    public void idle()
    {
       
        anim.SetInteger("state", IDLE);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EXP")
        {
            // increase EXP
            EXP.fillAmount += 0.05f;
           
        }
    }
}
