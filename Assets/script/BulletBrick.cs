using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBrick :   ShootBullet
{
    public float speed =500;
    int dame = 20;
    
    public long timeInitBullet = 2;
    float preTime = 0;
    bool flag_shoot = true;
    Rigidbody2D Rig;
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

            BulletBrick tmp = Instantiate(this, character.Instance.get_position(), Quaternion.identity);
            tmp.is_sample = false;
            tmp.gameObject.SetActive(true);
            preTime = Time.time;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_sample)
        {
            gameObject.SetActive(false);
            return;
        }
        if (flag_shoot)
        {
            flag_shoot = false ;
            float x = Random.Range(-0.5f, 0.5f);
            Debug.Log(x);
            Rig.AddForce(new Vector3 (x,1,0)* speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            if (is_sample)
            {
                dame = 0;
                gameObject.SetActive(false);
            }else 
                Destroy(this.gameObject);
            
        }
    }
}
