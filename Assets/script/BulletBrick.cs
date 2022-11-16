using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBrick :   ShootBullet
{
    public float speed =500;
    int dame = 20;
    
    public long timeInitBullet = 2;
    float preTime = 0;
    bool flag_shoot = false;
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
        flag_shoot = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        move();
        if (OutOfSreen())
        {
            Destroy(this.gameObject);
        }
    }
    void move()
    {
        if (flag_shoot)
        {
            flag_shoot = false;
            float x = Random.Range(-0.5f, 0.5f);
            Rig.AddForce(new Vector3(x, 1, 0) * speed);
        }
    }
   
}
