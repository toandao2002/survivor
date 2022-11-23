using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : ShootBullet
{
    public int dame = 20;
    public long timeInitBullet = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         
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
         
    }

    public override long get_init_bullet()
    {
        return timeInitBullet;
    }
}
