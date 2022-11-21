using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCommon : MonoBehaviour
{

    public GameObject EXP;
    public bool isCollide = false;
    public  int blood = 5;
    public int dame;
    public float step;
    public Animator ani;
    Vector3 scaleFirst;
    // Start is called before the first frame update
    private void Awake()
    {
        this.enabled = true;
    }
    void Start()
    {
        scaleFirst = transform.localScale;
        ani = GetComponent<Animator>();
    }
     
    // Update is called once per frame
    void Update()
    {
        
         if (character.Instance.blood <= 0) Time.timeScale = 0f;
        
        if (blood <= 0)
        {
            manage_zombie.Instace.zombies.Remove(this.gameObject);
            DestroyImmediate(this.gameObject.GetComponent<Collider2D>());
            this.gameObject.tag = "Untagged";
            Die();
            
        }
        else if (isCollide == false)
        {
            movetoCharacter();
            Run();
        }

        else
        {
            Attack();
        }
    }
    public void Attack()
    {
        ani.SetBool("Attack", true);
        ani.SetBool("Run", false);
    }
    public void Run()
    {
        ani.SetBool("Attack", false);
        ani.SetBool("Run", true);
    }
    public void Die()
    {
        ani.SetBool("Die", true);
        DG.Tweening.DOVirtual.DelayedCall(1.2f, () =>
        {
            int tmp = Int32.Parse(UI.Instance.amount_zombie_die.text);
            tmp++;
            UI.Instance.amount_zombie_die.text = tmp.ToString();
            Instantiate(EXP, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        });
    }
    public void movetoCharacter()
    {
        Vector3 dir =  character.Instance.get_position() - transform.position ;



        float angle = Vector2.Angle(dir, Vector2.up);
        if (dir.x > 0)
            transform.localScale = new Vector3(scaleFirst.x, transform.localScale.y, transform.localScale.z);
        else transform.localScale = new Vector3(scaleFirst.x * -1, transform.localScale.y, transform.localScale.z);


        transform.position = Vector3.MoveTowards(transform.position, character.Instance.transform.position, step* Time.timeScale);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            isCollide = true;
        }


        if (collision.gameObject.tag == "Bullet")
        {
            int tmp = collision.gameObject.GetComponent<ShootBullet>().GetDame();
            blood -= tmp;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        {

            isCollide = false;
        }
    }
    private int GetBlood()
    {
        return blood;
    }
    private void SetBlood(int value)
    {
        blood = value;
    }
    public int GetDame()
    {
        return dame;
    }

    public void SetDame(int value)
    {
        dame = value;
    }
}
