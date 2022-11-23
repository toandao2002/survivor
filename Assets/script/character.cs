using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    public int minute;
    public GameObject GameLose;
    public GameObject GameWin;
    public int  blood = 200;
    public Image bloodF;
    public List<Sprite> Item ;
    public GameObject ParticleLoseBlood;
    public static character Instance { get; private set; }
    
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
        if (Instance == null)
        {
            Item = new List<Sprite>();
            Instance = this;
        }
        
        bullets = new List<ShootBullet>();
        Time.timeScale = 1;
        /*gameObject.SetActive(false);
        GameWin.SetActive(false);*/

    }
     
    void Start()
    {
        if (Instance == null)
        {
            Item = new List<Sprite>();
            Instance = this;
        }
        preTime = (long)Time.time;
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
            var bullet = ObjectpoolBullet.Instance.GetPooledObject((int)(BulletName.kunai));
            bullet.transform.position = transform.position;
            bullet.GetComponent<ShootBullet>().shoot();
            yield return new WaitForSeconds(3);
        }
    }
    public   void AddNewBullet(BulletName bullet)
    {
          
        StartCoroutine( SpawnBullet(bullet));
    }
    public void IncreaseDame(BulletName bullet)
    {
        bullet_prefabs[(int)bullet].SetDame((int ) (bullet_prefabs[(int)bullet].GetDame()* 1.3f));
    }
    public void IncreaseSpeedBullet(BulletName bullet)
    {
       // bullet_prefabs[(int)bullet].SetDame((int)(bullet_prefabs[(int)bullet].GetDame() * 1.1f));
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

            var bullet = ObjectpoolBullet.Instance.GetPooledObject((int)(bulletname));
            bullet.transform.position = transform.position;
            bullet.GetComponent<ShootBullet>().shoot();
            ManageAudio.Instance.playSound((int) bulletname);
            
            yield return new WaitForSeconds(3);
        }
    }
     
   

    // Update is called once per frame
    void Update()
    {
        bloodF.fillAmount = (float)blood / 200;
        transform.Translate(new Vector3(joystick.Horizontal, joystick.Vertical) * speed * Time.deltaTime);
        main_camera.transform.position = transform.position + new Vector3(0, 0, -10);
        if (blood <= 0 && GameLose.gameObject.activeInHierarchy == false  ) // game lose 
        {   
            GameLose.SetActive(true);
            Time.timeScale = 0;
            ManageAudio.Instance.gameLose();
        }
        if (Time.time -preTime>= 60 * minute && GameWin.gameObject.activeInHierarchy == false)
        {
            GameWin.SetActive(true);
            Time.timeScale = 0;
            ManageAudio.Instance.gameWin();
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
        if (collision.gameObject.tag == "EXP"  )
        {
            // increase EXP
            if (EXP.fillAmount >= 1) return;
            ManageAudio.Instance.EXP();
            EXP.fillAmount += 0.05f;
            
        }
        if (collision.gameObject.tag =="Zombie")
        {
            

        }
    }
    float timeBehurt;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timeBehurt == 0) timeBehurt = Time.time;
        if (collision.gameObject.tag == "Zombie" && Time.time - timeBehurt > 0.5)
        {
            timeBehurt = Time.time;
            blood -= collision.gameObject.GetComponent<ZombieCommon>().GetDame();
            Instantiate(ParticleLoseBlood, transform.position, Quaternion.identity);
            ManageAudio.Instance.Behurt();

        }
    }
    
    

    public Vector3 get_position()
    {
        return transform.position;
    }
}
