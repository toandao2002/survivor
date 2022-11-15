using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_rocket : ShootBullet
{
    zombies zombie;
    public GameObject Explosion;
    public float speed;
    int dame = 20;
    Vector3 des;
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


        if (is_sample)
        {
            dame = 0;
            gameObject.SetActive(false);
            return;

        }
        gameObject.SetActive(true);
        if (zombie != null)
        {
            des = zombie.transform.position;
            // quay doi tuong theo huong
            Vector3 dir = zombie.transform.position - character.Instance.get_position();
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, (angle - 90));
            //  di chuyem bullet 
            
        }

        if (transform.position == des)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, des, speed);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
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
                tmp.zombie = zombie;
                tmp.gameObject.SetActive(true);
                preTime = Time.time;

            }

        }
    }
}
