using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    public Image EXP;
    public Joystick joystick;
    public float speed;
    Animator anim;
    public Shoot_kunai shoot_kunai;
    const int IDLE = 0;
    const int WALK = 1;
    public long   timeInitBullet , preTime ;
    // Start is called before the first frame update
    void Start()
    {
        preTime = (long)Time.realtimeSinceStartup;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(joystick.Horizontal, joystick.Vertical) * speed * Time.deltaTime);

        if (Time.realtimeSinceStartup - preTime > timeInitBullet)
        {
           
            shoot();
            
            preTime =(long ) Time.realtimeSinceStartup;

        }
        
    }
    void shoot()
    {
        zombies zombies;
        zombies = FindObjectOfType<zombies>();
        if (zombies != null)
        {
            Instantiate(shoot_kunai, transform.position , Quaternion.identity );
        }
             
    }
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
