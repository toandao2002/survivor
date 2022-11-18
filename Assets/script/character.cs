using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{

    public int  blood = 200; 
    public static character Instance { get; private set; }
    public Vector3 get_position()
    {
        return transform.position;
    }
    List<ShootBullet> bullets;
    public Camera main_camera;
    public float speed;
    public Image EXP;
    public GameObject choseBullet;
    public List<ShootBullet> bullet_prefabs;
    //public BulletBrick bulletBrick;
    //public manage_haunrs haurs;
    public Joystick joystick;

    Animator anim;
    //public Shoot_kunai shoot_kunai;
    const int IDLE = 0;
    const int WALK = 1;
    public long timeInitBullet, preTime;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        bullets = new List<ShootBullet>();
       
    }
    void Start()
    {
        preTime = (long)Time.realtimeSinceStartup;
        anim = GetComponent<Animator>();

        /* StartCoroutine(SpawnBulletBrick());

         StartCoroutine(SpawnBulletRocket());
         StartCoroutine(SpawnBulletZuantoudan());*/
        StartCoroutine(SpawnBullet(BulletName.kunai));
    }

    IEnumerator IESpawnBulletExample()
    {
        while (true)
        {
            var bullet = Instantiate(bullet_prefabs[(int)BulletName.example], transform.position, Quaternion.identity);
          //  bullet.shoot();
            yield return new WaitForSeconds(3);
        }
    }
    public   void AddNewBullet(string bullet)
    {
         
        BulletName tmp =(BulletName) Enum.Parse(typeof(BulletName), bullet);
        StartCoroutine( SpawnBullet(tmp));
    }
    
    IEnumerator SpawnBullet(BulletName bulletname )
    {
        while (true)
        {
            if (bulletname == BulletName.huanr)
            {
                ShootBullet bullet2 = null; ;
                try {
                    bullet2 = FindObjectOfType<manage_haunrs>().GetComponent<ShootBullet>();
                }
                catch
                {

                }
                
                if (bullet2 == null) bullet2 = Instantiate(bullet_prefabs[(int)bulletname], transform.position, Quaternion.identity);
                bullet2.shoot();
                break;
            }
            
            var bullet = Instantiate(bullet_prefabs[(int)bulletname], transform.position, Quaternion.identity);
            bullet.shoot();
            
            yield return new WaitForSeconds(3);
        }
    }
     
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(joystick.Horizontal, joystick.Vertical) * speed * Time.deltaTime);
        main_camera.transform.position = transform.position + new Vector3(0, 0, -10);
        if (blood <= 0) // game lose 
        {

        }

        if (EXP.fillAmount >= 1)
        {

            choseBullet.GetComponentInChildren<SelectSkillPopup>().enabled = true;
            choseBullet.SetActive(true);
            
            EXP.fillAmount = 0;
        }
        HandleAni();
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
    public void HandleAni()
    {
        if (joystick.Horizontal ==0 && joystick.Vertical==0)
            anim.SetInteger("state", IDLE);
        else 
            anim.SetInteger("state", WALK);
        if (joystick.Horizontal > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if (joystick.Horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EXP")
        {
            // increase EXP
            if (EXP.fillAmount >= 1) return; 
            EXP.fillAmount += 0.05f;
            
        }
    }
}
