using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dameExplosion : ShootBullet
{   
    public int Dame = 20;
    public long timeInitBullet = 2;
    public override int GetDame()
    {
        return 20;
    }

    public override long get_init_bullet()
    {
        return timeInitBullet;
    }

    public override void SetDame(int value)
    {
         
    }

    public override void shoot()
    {
         
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
