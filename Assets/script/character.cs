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
    List<ShootBullet> bullets;
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
       
        StartCoroutine(SpawnBulletBrick());
        StartCoroutine(SpawnBulletKunai());
        StartCoroutine(SpawnBulletRocket());
        StartCoroutine(SpawnBulletZuantoudan());
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
    IEnumerator SpawnBulletZuantoudan()
    {
        while (true)
        {
            var bullet = Instantiate(bullet_prefabs[(int)BulletName.zuanto], transform.position, Quaternion.identity);
            bullet.shoot();
            yield return new WaitForSeconds(3);
        }
    }
    IEnumerator SpawnBulletKunai()
    {
        while (true)
        {
            var bullet = Instantiate(bullet_prefabs[(int)BulletName.kunai], transform.position, Quaternion.identity);
            bullet.shoot();
            yield return new WaitForSeconds(3);
        }
    }
    IEnumerator SpawnBulletBrick()
    {
        while (true)
        {
            var bullet = Instantiate(bullet_prefabs[(int)BulletName.brick], transform.position, Quaternion.identity);
            bullet.shoot();
            yield return new WaitForSeconds(3);
        }
    }
    IEnumerator SpawnBulletRocket()
    {
        while (true)
        {
            var bullet = Instantiate(bullet_prefabs[(int)BulletName.rocket], transform.position, Quaternion.identity);
            bullet.shoot();
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(joystick.Horizontal, joystick.Vertical) * speed * Time.deltaTime);
        main_camera.transform.position = transform.position + new Vector3(0, 0, -10);
        
        if (EXP.fillAmount >= 1)
        {

            bullets.Add(Instantiate(bullet_prefabs[(int)BulletName.huanr], transform.position, Quaternion.identity));
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
            EXP.fillAmount += 0.05f;

        }
    }
}
