using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExample : ShootBullet
{   
    
    public override int GetDame()
    {
        return 0; 
    }

    public override void SetDame(int value)
    {
    }

    public override void shoot()
    {
        // setup vi tri, huong bay
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        // move
        transform.Translate(Vector3.right);
    }

    public override void CollisionWithZombie(Transform zombie)
    {
        base.CollisionWithZombie(zombie);
        Destroy(gameObject);
    }
}
